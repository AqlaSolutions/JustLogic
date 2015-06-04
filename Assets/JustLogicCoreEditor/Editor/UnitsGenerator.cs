using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using JustLogic.Core;
using System.Linq;
using UnityEngine;

namespace JustLogic.Editor
{
    public class UnitsGenerator
    {
        public string Prefix { get; set; }
        public bool HideExpressions { get; set; }
        public string MenuRoot { get; set; }
        public string Path { get; set; }
        public string MenuSuffix { get; set; }
        public Type[] IgnoreParameterTypes { get; set; }
        public string FriendlyNamePrefix { get; set; }
        public bool IncludeBaseTypes { get; set; }

        public UnitsGenerator(string prefix = "JL", bool hideExpressions = false, string menu = "", string path = "", string menuSuffix = "", string friendlyNamePrefix = "", Type[] ignoreTypes = null, bool includeBaseTypes = false)
        {
            Prefix = prefix;
            HideExpressions = hideExpressions;
            MenuRoot = menu;
            Path = path;
            MenuSuffix = menuSuffix;
            IgnoreParameterTypes = ignoreTypes;
            IncludeBaseTypes = includeBaseTypes;
            FriendlyNamePrefix = friendlyNamePrefix;
        }

        public void Generate(TypeInfo type)
        {
            #region Setup

            const string ext = ".cs";

            Path = Path.Replace("\\", "/");
            if (!Path.EndsWith("/"))
                Path += "/";

            var typeFullName = type.Type.ToCSharpString();
            if (!string.IsNullOrEmpty(MenuRoot) && !MenuRoot.EndsWith("/"))
                MenuRoot += "/";

            var usedList = new HashSet<string>();
            foreach (var expression in Library.Expressions)
                usedList.Add(expression.Type.GetSimpleName());
            foreach (var expression in Library.Actions)
                usedList.Add(expression.Type.GetSimpleName());

            #endregion

            #region Methods

            foreach (var methodInfo in type.Methods
                                           .Select(m => new { Method = m.Method, Parameters = m.Pointer.Parameters }).OrderBy(m => m.Parameters.Count))
            {
                var method = methodInfo.Method;
                var parameters = methodInfo.Parameters;

                #region Filter

                if (!IncludeBaseTypes && (method.DeclaringType!=type)) continue;
                if (!method.IsPublic) continue;
                if (method.ContainsGenericParameters) continue;
                if (method.DeclaringType == typeof(object)) continue;
                if (method.Name == "GetHashCode") continue;
                if (method.Name == "Equals") continue;
                if (method.Name == "ToString") continue;
                if (Attribute.IsDefined(method, typeof(ObsoleteAttribute))) continue;
                if (parameters.Any(p => typeof(Delegate).IsAssignableFrom(p.ParameterType))) continue;
                int refOrOutCount = parameters.Count(p => p.ParameterType.IsByRef || p.IsOut);
                if (refOrOutCount != 0 && (refOrOutCount != 1 || method.ReturnType != typeof(void))) continue;
                if (method.IsSpecialName && (method.Name.StartsWith("get_") || method.Name.StartsWith("set_")))
                {
                    var property = type.Type.GetProperty(method.Name.Substring(4));
                    if (property != null)
                        if (Attribute.IsDefined(property, typeof(ObsoleteAttribute))) continue;
                }
                if (IgnoreParameterTypes != null && parameters.Any(
                    p =>
                    {
                        var elType = p.ParameterType;
                        if (elType.IsByRef)
                        {
                            elType = elType.GetElementType();
                            System.Diagnostics.Debug.Assert(elType != null, "elType != null");
                        }
                        if (elType.IsArray)
                            elType = elType.GetElementType();
                        return IgnoreParameterTypes.Any(t => t == elType);
                    })) continue;

                #endregion

                var sb = new StringBuilder();
                WriteUsings(type, sb);

                #region Class Name

                string className;
                string unprefixedClassName;

                var isConverter = method.IsSpecialName && (method.Name == "op_Implicit" || method.Name == "op_Explicit");
                if (isConverter)
                    unprefixedClassName = parameters[0].ParameterType.GetSimpleName() + "To" + method.ReturnType.GetSimpleName();
                else
                {
                    unprefixedClassName = GenerateClassName(method.Name);
                }

                MakeUniqueClassName(usedList, out className, ref unprefixedClassName);

                #endregion

                #region Return Type

                Type returnType;
                ParameterInfo returnParameter = null;
                if (method.ReturnType != typeof(void))
                    returnType = method.ReturnType;
                else
                {
                    returnParameter = parameters.FirstOrDefault(p => p.IsOut || p.ParameterType.IsByRef);
                    if ((returnParameter != null) && returnParameter.ParameterType.IsByRef)
                        returnType = returnParameter.ParameterType.GetElementType();
                    else returnType = null;
                }
                bool returnsValueType = false;
                if (!method.IsStatic && type.Type.IsValueType && method.ReturnType == typeof(void))
                {
                    returnsValueType = true;
                    returnType = type;
                }
                bool isSetter = method.IsSpecialName && method.Name.StartsWith("set_");
                if ((returnType == null) && isSetter)
                    returnType = parameters[0].ParameterType;

                bool isExpression = returnType != null;

                #endregion

                #region Header

                WriteMenuAttributes(sb, unprefixedClassName, isExpression ? returnType.ToCSharpString() : null,
                                    isConverter ? type.FriendlyName : null, isConverter,
                                    hideExpressions: isSetter ? (bool?)false : null);



                WriteClassHeader(className, isExpression, sb);

                #endregion

                #region Parameters

                if (!method.IsStatic)
                    WriteParameterForMember("OperandValue", typeFullName, false, sb);

                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.IsOut) continue; // don't need input for out parameter
                    var t = parameter.ParameterType;
                    if (t.IsByRef) // input for ref parameter
                        t = t.GetElementType();

                    WriteParameterForMember(parameter.Name, t, sb);
                }

                #endregion

                #region Execution Method

                #region Before Invokation

                if (isExpression)
                {
                    WriteExpressionHeader(sb);
                    if (returnParameter != null)
                    {
                        WriteMethodIndent(sb);
                        sb.Append(returnType.ToCSharpString() + " r");
                        if (!returnParameter.IsOut)
                            sb.Append(returnParameter.Name);
                        //sb.Append(returnType.IsValueType ? " = new " + returnType.FullName + "()" : " = null");
                        sb.AppendLine(";");
                    }
                    WriteMethodIndent(sb);
                }
                else
                {
                    WriteActionHeader(sb);
                    WriteMethodIndent(sb);
                }
                if (!method.IsStatic)
                {
                    sb.AppendLine(typeFullName + " opValue = OperandValue.GetResult<" + typeFullName + ">(context);");
                    WriteMethodIndent(sb);
                }

                if (isExpression && (returnParameter == null) && !returnsValueType)
                    sb.Append("return ");

                #endregion

                #region Invokation - Special Names

                string methodName = method.Name;
                if (method.IsSpecialName)
                {
                    if (methodName.StartsWith("get_"))
                    {
                        methodName = methodName.Substring(4);

                        sb.Append(method.IsStatic ? typeFullName : "opValue");

                        if (methodName == "Item")
                        {
                            sb.Append("[");
                            WriteMethodParameters(parameters, 0, parameters.Count, sb);
                            sb.Append("]");
                        }
                        else
                        {
                            sb.Append(".");
                            sb.Append(methodName);
                        }
                        sb.AppendLine(";");
                    }
                    else if (methodName.StartsWith("set_"))
                    {
                        methodName = methodName.Substring(4);

                        sb.Append(method.IsStatic ? typeFullName : "opValue");

                        if (methodName == "Item")
                        {
                            sb.Append("[");
                            WriteMethodParameters(parameters, 0, parameters.Count - 1, sb);
                            sb.Append("]");
                        }
                        else
                        {
                            sb.Append(".");
                            sb.Append(methodName);
                        }
                        sb.Append(" = ");
                        WriteMethodParameters(parameters, parameters.Count - 1, 1, sb);
                        sb.AppendLine(";");
                    }
                    else if (isConverter)
                    {
                        sb.Append("(").Append(method.ReturnType.ToCSharpString()).Append(")");
                        WriteMethodParameters(parameters, 0, 1, sb);
                        sb.AppendLine(";");
                    }
                    else if (methodName == "op_UnaryNegation")
                    {
                        sb.Append("-");
                        WriteMethodParameters(parameters, 0, 1, sb);
                        sb.AppendLine(";");
                    }
                    else
                    {
                        string delimiter;
                        switch (methodName)
                        {
                            case "op_Multiply":
                                delimiter = " * ";
                                break;
                            case "op_Subtraction":
                                delimiter = " - ";
                                break;
                            case "op_Addition":
                                delimiter = " + ";
                                break;
                            case "op_Equality":
                                delimiter = " == ";
                                break;
                            case "op_Division":
                                delimiter = " / ";
                                break;
                            case "op_Inequality":
                                delimiter = " != ";
                                break;
                            default:
                                throw new Exception("Delimiter not found for " + methodName);
                        }
                        WriteMethodParameters(parameters, 0, 2, sb, delimiter);
                        sb.AppendLine(";");
                    }
                }
                else
                #endregion

                #region Invokation - Standard Method

                {
                    sb.Append(method.IsStatic ? typeFullName : "opValue");
                    sb.Append(".");
                    sb.Append(method.Name);
                    sb.Append("(");
                    WriteMethodParameters(parameters, 0, parameters.Count, sb);
                    sb.AppendLine(");");
                }

                #endregion

                #region Footer

                if (isExpression)
                {
                    if (returnParameter != null)
                        WriteWithMethodIndent("return r;\r\n", sb);
                    else if (returnsValueType)
                        WriteWithMethodIndent("return opValue;\r\n", sb);
                }
                else
                    WriteWithMethodIndent("return null;\r\n", sb);
                WriteMethodAndClassFooter(sb);

                #endregion

                #endregion

                File.WriteAllText(Path + className + ext, sb.ToString());
            }

            #endregion

            #region Constructors

            foreach (var constructorInfo in type.Type.GetConstructors()
                                           .Select(m => new { Method = m, Parameters = (IList<ParameterInfo>)m.GetParameters() })
                                           .OrderBy(m => m.Parameters.Count))
            {
                if (Attribute.IsDefined(constructorInfo.Method, typeof(ObsoleteAttribute))) continue;
                var parameters = constructorInfo.Parameters;

                #region Filter

                if (parameters.Any(p => typeof(Delegate).IsAssignableFrom(p.ParameterType))) continue;
                int refOrOutCount = parameters.Count(p => p.ParameterType.IsByRef || p.IsOut);
                if (refOrOutCount != 0) continue;

                if (IgnoreParameterTypes != null && parameters.Any(
                    p =>
                    {
                        var elType = p.ParameterType;
                        if (elType.IsByRef)
                        {
                            elType = elType.GetElementType();
                            System.Diagnostics.Debug.Assert(elType != null, "elType != null");
                        }
                        if (elType.IsArray)
                            elType = elType.GetElementType();
                        return IgnoreParameterTypes.Any(t => t == elType);
                    })) continue;

                #endregion

                var sb = new StringBuilder();

                WriteUsings(type, sb);

                string className;
                string unprefixedClassName = "New" + type.Type.GetSimpleName();
                MakeUniqueClassName(usedList, out className, ref unprefixedClassName);
                WriteMenuAttributes(sb, unprefixedClassName, typeFullName, skipSuffix: true);
                WriteClassHeader(className, true, sb);

                foreach (ParameterInfo parameter in parameters)
                    WriteParameterForMember(parameter.Name, parameter.ParameterType, sb);

                WriteExpressionHeader(sb);
                WriteMethodIndent(sb);
                sb.Append("return new ");
                sb.Append(typeFullName);
                sb.Append("(");
                WriteMethodParameters(parameters, 0, parameters.Count, sb);
                sb.AppendLine(");");
                WriteMethodAndClassFooter(sb);

                File.WriteAllText(Path + className + ext, sb.ToString());
            }

            #endregion

            #region Field getters

            foreach (var field in type.Fields.Where(f => f.IsPublic))
            {
                if (!IncludeBaseTypes && (field.DeclaringType != type)) continue;
                if (Attribute.IsDefined(field, typeof(ObsoleteAttribute))) continue;
                if (IgnoreParameterTypes != null && IgnoreParameterTypes.Any(t => t == field.FieldType)) continue;
                var sb = new StringBuilder();
                WriteUsings(type, sb);

                string className;
                string unprefixedClassName = "Get" + GenerateClassName(field.Name);
                MakeUniqueClassName(usedList, out className, ref unprefixedClassName);

                WriteMenuAttributes(sb, unprefixedClassName, field.FieldType.ToCSharpString());
                WriteClassHeader(className, true, sb);

                if (!field.IsStatic)
                    WriteParameterForMember("OperandValue", typeFullName, false, sb);

                WriteExpressionHeader(sb);
                WriteMethodIndent(sb);

                if (!field.IsStatic)
                {
                    sb.AppendLine(typeFullName + " opValue = OperandValue.GetResult<" + typeFullName + ">(context);");
                    WriteMethodIndent(sb);
                }

                sb.Append("return ");

                sb.Append(field.IsStatic ? typeFullName : "opValue");
                sb.Append(".");
                sb.Append(field.Name);
                sb.AppendLine(";");

                WriteMethodAndClassFooter(sb);

                File.WriteAllText(Path + className + ext, sb.ToString());
            }

            #endregion
            #region Field setters

            foreach (var field in type.Fields.Where(f => !f.IsInitOnly && !f.IsLiteral).Where(f => f.IsPublic))
            {
                if (!IncludeBaseTypes && (field.DeclaringType != type)) continue;
                if (Attribute.IsDefined(field, typeof(ObsoleteAttribute))) continue;
                if (IgnoreParameterTypes != null && IgnoreParameterTypes.Any(t => t == field.FieldType)) continue;

                var sb = new StringBuilder();
                WriteUsings(type, sb);

                string className;
                string unprefixedClassName = "Set" + GenerateClassName(field.Name);
                MakeUniqueClassName(usedList, out className, ref unprefixedClassName);

                WriteMenuAttributes(sb, unprefixedClassName, field.FieldType.ToCSharpString(), hideExpressions: false);

                WriteClassHeader(className, true, sb);

                if (!field.IsStatic)
                    WriteParameterForMember("Target", typeFullName, false, sb);
                WriteParameterForMember("Value", field.FieldType, sb);
                WriteExpressionHeader(sb);
                WriteMethodIndent(sb);
                if (!field.IsStatic)
                {
                    sb.AppendLine(typeFullName + " opValue = Target.GetResult<" + typeFullName + ">(context);");
                    WriteMethodIndent(sb);
                }
                sb.Append("return ");
                sb.Append(field.IsStatic ? typeFullName : "opValue");
                sb.Append(".");
                sb.Append(field.Name);
                sb.Append(" = ");
                WriteMethodParameter("Value", field.FieldType, sb);
                sb.AppendLine(";");
                WriteMethodAndClassFooter(sb);
                File.WriteAllText(Path + className + ext, sb.ToString());

            }

            #endregion

        }

        private void MakeUniqueClassName(HashSet<string> usedList, out string className, ref string unprefixedClassName)
        {
            className = (Prefix + unprefixedClassName);
            int counter = 1;
            bool needsUnderline = char.IsNumber(className[className.Length - 1]);

            string newName = className;
            while (!usedList.Add(newName))
            {
                newName = className;
                if (needsUnderline)
                    newName += "_";
                newName += (++counter);
            }

            if (counter != 1)
            {
                if (needsUnderline)
                {
                    unprefixedClassName += "_";
                    className += "_";
                }

                //unprefixedClassName += counter.ToString(CultureInfo.InvariantCulture);
                className += counter.ToString(CultureInfo.InvariantCulture);
            }
        }

        private static string GenerateClassName(string unprefixedClassName)
        {
            unprefixedClassName = unprefixedClassName.TrimStart('_');
            if (char.IsLower(unprefixedClassName[0]))
                unprefixedClassName = char.ToUpper(unprefixedClassName[0]).ToString(CultureInfo.InvariantCulture) + unprefixedClassName.Substring(1);
            unprefixedClassName = TypeInfo.GenerateMemberFriendlyName(unprefixedClassName).Replace(" ", "");
            return unprefixedClassName;
        }

        private static void WriteMethodAndClassFooter(StringBuilder sb)
        {
            sb.AppendLine("    }");
            sb.AppendLine("}");
        }

        private static void WriteClassHeader(string className, bool isExpression, StringBuilder sb)
        {
            sb.AppendLine("public class " + className + " : " + (isExpression ? typeof(JLExpression).Name : typeof(JLAction).Name));
            sb.AppendLine("{");
        }

        private static void WriteMethodIndent(StringBuilder sb)
        {
            sb.Append("        ");
        }

        private static void WriteWithMethodIndent(string s, StringBuilder sb)
        {
            sb.Append("        ");
            sb.Append(s);
        }

        private static void WriteActionHeader(StringBuilder sb)
        {
            sb.AppendLine("    protected override IEnumerator<YieldMode> OnExecute(" + typeof(IExecutionContext).Name + " context)");
            sb.AppendLine("    {");
        }

        private static void WriteExpressionHeader(StringBuilder sb)
        {
            sb.AppendLine("    public override object GetAnyResult(" + typeof(IExecutionContext).Name + " context)");
            sb.AppendLine("    {");
        }

        private static void WriteParameterForMember(string memberName, Type memberType, StringBuilder sb)
        {
            bool isArray = memberType.IsArray;
            if (isArray)
                memberType = memberType.GetElementType();
            var memberTypeFullName = memberType.ToCSharpString();
            WriteParameterForMember(memberName, memberTypeFullName, isArray, sb);
        }

        public static bool IsExpressionMember(string memberName, string memberTypeFullName)
        {
            if (memberTypeFullName == typeof(int).FullName)
            {
                string parsingName = memberName;
                while ((parsingName.Length > 0) && (!char.IsLetter(parsingName[parsingName.Length - 1])))
                    parsingName = parsingName.Remove(parsingName.Length - 1, 1);

                if (parsingName.StartsWith("LayerMask", StringComparison.OrdinalIgnoreCase))
                    return false;
                else if (parsingName.StartsWith("Layer", StringComparison.OrdinalIgnoreCase) && (memberName.Length <= "Layer32".Length))
                    return false;
            }
            return true;
        }

        private static void WriteParameterForMember(string memberName, string memberTypeFullName, bool isArray, StringBuilder sb)
        {
            memberName = TypeInfo.GenerateMemberFriendlyName(memberName).Replace(" ", "");

            bool isLayerMask = false;
            bool isLayer = false;
            if (memberTypeFullName == typeof(int).FullName)
            {
                string parsingName = memberName;
                while ((parsingName.Length > 0) && (!char.IsLetter(parsingName[parsingName.Length - 1])))
                    parsingName = parsingName.Remove(parsingName.Length - 1, 1);

                if (parsingName.StartsWith("LayerMask", StringComparison.OrdinalIgnoreCase))
                    isLayerMask = true;
                else if (parsingName.StartsWith("Layer", StringComparison.OrdinalIgnoreCase) && (memberName.Length <= "Layer32".Length))
                    isLayer = true;
            }
            bool explicitType = isLayerMask || isLayer;
            sb.Append("    [Parameter(");
            if (!explicitType)
            {
                sb.Append("ExpressionType = typeof(");
                sb.Append(memberTypeFullName);
                sb.Append(")");
            }
            else if (isLayer)
                sb.Append("OverrideType = ParameterAttribute.OverrideTypes.Layer");
            else
                sb.Append("OverrideType = ParameterAttribute.OverrideTypes.LayerMask");

            sb.AppendLine(")]");
            sb.Append("    public ");
            sb.Append(explicitType ? memberTypeFullName : typeof(JLExpression).Name);
            if (isArray)
                sb.Append("[]");
            sb.Append(" ");
            sb.Append(memberName);
            if (isLayerMask)
                sb.Append(" = -1");
            sb.AppendLine(";");
            sb.AppendLine();
        }

        private void WriteMenuAttributes(StringBuilder sb, string name, string returnTypeFullName = null, string containerName = null, bool skipSuffix = false, bool? hideExpressions = null)
        {

            string friendly = TypeInfo.GenerateMemberFriendlyName(name);
            if (MenuRoot != null)
            {
                sb.Append("[UnitMenu(\"");
                sb.Append(MenuRoot);
                sb.Append(friendly);
                if (!skipSuffix)
                    sb.Append(MenuSuffix);
                sb.AppendLine("\")]");
            }
            sb.Append("[UnitFriendlyName(\"");
            if (containerName != null)
                sb.Append(containerName + ".");
            else
                name = FriendlyNamePrefix + friendly;
            sb.AppendLine(name + "\")]");

            if (returnTypeFullName != null)
            {
                sb.Append("[UnitUsage(typeof(" + returnTypeFullName + ")");
                if (hideExpressions.GetValueOrDefault(HideExpressions))
                    sb.Append(", HideExpressionInActionsList = true");
                sb.AppendLine(")]");
            }
        }

        private static void WriteUsings(TypeInfo type, StringBuilder sb)
        {
            sb.AppendLine("using JustLogic.Core;");
            sb.AppendLine("using System.Collections.Generic;");
            if (!string.IsNullOrEmpty(type.Type.Namespace) && type.Type.Namespace != "global::")
                sb.AppendLine("using " + type.Type.Namespace + ";");
            sb.AppendLine();
        }

        private static void WriteMethodParameters(IList<ParameterInfo> parameters, int start, int length, StringBuilder sb, string delimiter = ", ")
        {
            bool first = true;
            for (int i = start; i - start < length; i++)
            {
                ParameterInfo parameter = parameters[i];
                if (first)
                    first = false;
                else
                    sb.Append(delimiter);

                if (parameter.IsOut)
                {
                    sb.Append("out r");
                    continue;
                }
                var t = parameter.ParameterType;
                if (t.IsByRef)
                {
                    sb.Append("ref r");
                    continue;
                }
                WriteMethodParameter(parameter.Name, t, sb);
            }
        }

        private static void WriteMethodParameter(string parameter, Type type, StringBuilder sb)
        {
            bool isArray = type.IsArray;
            if (isArray)
            {
                type = type.GetElementType();
                System.Diagnostics.Debug.Assert(type != null, "type != null");
            }
            sb.Append(TypeInfo.GenerateMemberFriendlyName(parameter).Replace(" ", ""));
            if (IsExpressionMember(parameter, type.FullName))
            {
                sb.Append(".GetResult<");
                sb.Append(type.ToCSharpString());
                sb.Append(">(context)");
            }
        }
    }
}