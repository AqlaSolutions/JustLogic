using System;
using System.Linq;
using System.Reflection;
using System.Text;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(MethodInvokationBase), Order = int.MaxValue)]
    public class InvokationDrawer : ParameterDrawerBase
    {
        readonly LongListSelector _typeSelector = new LongListSelector(DrawersLibrary.TypesListShort, DrawersLibrary.TypesList, label: "Target: ", filter: "UnityEngine.");
        LongListSelector _methodSelector;
        IParameterDrawer _targetSelectorDrawer;
        bool _changed;

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            var invokation = (MethodInvokationBase)value;
            if (invokation == null)
            {
                _changed = true;
                value = invokation = Library.Instantiator.CreateMethodInvokationBase();
            }
            bool r = base.Initialize(args, value, context);
            if (r)
            {

            }
            return r;
        }

        public override void Dispose()
        {
            if (_targetSelectorDrawer != null)
                _targetSelectorDrawer.Dispose();
            if (_argumentsCache.ArgumentDrawers != null)
                foreach (var drawer in _argumentsCache.ArgumentDrawers)
                    if (drawer != null) drawer.Dispose();
            if (_argumentsCache.OutVariableDrawers != null)
                foreach (var drawer in _argumentsCache.OutVariableDrawers)
                    if (drawer != null) drawer.Dispose();
            base.Dispose();
        }

        private Type DrawTypeSelector(Type invokationTargetType, MethodInvokationBase invokation, IDrawContext context, ref bool changed, out bool resetMethod)
        {
            resetMethod = false;
            if (_typeSelector.Draw(context))
            {
                var fullName = _typeSelector.FullValue;
                var newInvokationTargetType = Library.FindType(fullName) ?? typeof(Object);

                if (newInvokationTargetType != invokationTargetType)
                {
                    changed = true;
                    if (!newInvokationTargetType.Type.IsAssignableFrom(invokationTargetType))
                    {
                        resetMethod = true;
                        invokation.MethodAccessor = null;
                        if (invokation.Target)
                            invokation.Target = JLScriptableHelper.ReplaceUnit<JLExpression, JLNullReferenceBase>(invokation.Target);
                    }
                    invokationTargetType = newInvokationTargetType;
                    invokation.ExpressionType = fullName;
                    if ((invokation.Target is JLNullReferenceBase) && typeof(Object).IsAssignableFrom(invokationTargetType))
                        invokation.Target = JLScriptableHelper.ReplaceUnit<JLExpression, Object>(invokation.Target);

                    ReplaceTargetSelector(invokationTargetType, invokation, context);
                }
            }
            return invokationTargetType;
        }

        private bool DrawTargetSelector(MethodInvokationBase invokation, IDrawContext context)
        {
            bool changed = false;
            if (_targetSelectorDrawer != null)
            {
                if (_targetSelectorDrawer.SimpleDraw(context))
                {
                    invokation.Target = (JLExpression)_targetSelectorDrawer.Value;
                    changed = true;
                }
            }
            else if (invokation.Target)
            {
                invokation.Target = null;
                changed = true;
            }
            return changed;
        }

        private void ReplaceTargetSelector(Type invokationTargetType, MethodInvokationBase invokation, IDrawContext context)
        {
            if (_targetSelectorDrawer != null) _targetSelectorDrawer.Dispose();
            _targetSelectorDrawer = CreateTargetDrawer(invokationTargetType, invokation, _typeSelector.Expanded, context);
        }

        private IParameterDrawer CreateTargetDrawer(Type invokationTargetType, MethodInvokationBase invokation, bool expanded, IDrawContext context)
        {
            return InitArgs.Factory.CreateDrawer(new DrawerInitArgs(typeof(JLExpression), "Target: ", expressionType: (invokationTargetType == null || (!expanded && (invokation.Target is JLObjectValueBase))) ? typeof(Object) : invokationTargetType), invokation.Target, context);
        }

        void InitializeMethodSelector(Type invokationTargetType, out TypeInfo info, out MethodInfo[] methods, out string[] methodNames)
        {
            if (invokationTargetType == _cacheTargetType)
            {
                info = _cacheTargetType;
                methods = _cacheMethods;
                methodNames = _cacheMethodNames;
            }
            else
            {
                _cacheTargetType = info = invokationTargetType;
                _cacheMethods = methods = info.Methods.Select(m => m.Method).ToArray();
                _cacheMethodNames = methodNames = info.Methods.Select(m => FormatMethodName(m)).ToArray();
                _methodSelector = new LongListSelector(methodNames,
                    searchValues: info.Methods.Select(m => FormatMethodName(m, false)).ToArray(), label: "Method: ");
            }

        }

        string[] _cacheMethodNames;
        TypeInfo _cacheTargetType;
        MethodInfo[] _cacheMethods;

        private bool DrawMethodSelector(string currentMethodName, MethodInvokationBase invokation, IDrawContext context, ref MethodInfo method,
                                        MethodInfo[] methods, ref bool hasMethod, ref bool hasStaticMethod, ref SerializableMethodBase methodData)
        {
            if (_methodSelector.Draw(context, currentMethodName))
            {
                if (_methodSelector.CurrentValueIndex == -1)
                {
                    hasMethod = true;
                    invokation.SetMethod(null);
                    hasStaticMethod = false;
                    methodData = null;
                }
                else
                {
                    hasMethod = true;
                    invokation.SetMethod(method = methods[_methodSelector.CurrentValueIndex],
                        f =>
                        {
                            JLScriptableHelper.Destroy(f.Value);
                            JLScriptableHelper.Destroy(f.OutVariableAccessor);
                        });
                    hasStaticMethod = method.IsStatic;
                    methodData = invokation.MethodAccessor;
                }
                return true;
            }
            return false;
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = true;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        bool _inited;

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = _changed;
            _changed = false;

            #region setup

            var invokation = (MethodInvokationBase)Value;
            Type invokationTargetType = !string.IsNullOrEmpty(invokation.ExpressionType)
                                            ? Library.FindType(invokation.ExpressionType).Type ?? typeof(Object)
                                            : typeof(Object);

            SerializableMethodBase methodData = invokation.MethodAccessor;
            bool hasMethod = methodData.IsExistAndValid(invokationTargetType);
            if (!hasMethod)
                invokation.MethodAccessor = null;
            MethodInfo method = hasMethod ? methodData.MethodInfo : null;
            if (hasMethod && (method == null))
                hasMethod = false;
            // reset target for static methods
            var hasStaticMethod = hasMethod && method.IsStatic;
            if (hasStaticMethod && invokation.Target && !(invokation.Target is JLNullReferenceBase))
            {
                invokation.Target = JLScriptableHelper.ReplaceUnit<JLExpression, JLNullReferenceBase>(invokation.Target);
                changed = true;
            }

            if (!_inited)
            {
                ReplaceTargetSelector(invokationTargetType, invokation, context);
                _inited = true;
            }

            #endregion

            #region type and target

            _typeSelector.CurrentValueIndex = DrawersLibrary.TypesList.IndexOf(invokationTargetType.FullName);

            if (_typeSelector.Expanded)
            {
                bool resetMethod;
                invokationTargetType = DrawTypeSelector(invokationTargetType, invokation, context, ref changed, out resetMethod);
                if (resetMethod)
                {
                    hasMethod = false;
                    hasStaticMethod = false;
                }

                if (DrawTargetSelector(invokation, context)) changed = true;

                if (!_typeSelector.Expanded)
                    ReplaceTargetSelector(invokationTargetType, invokation, context);
            }
            else
            {
                if (_typeSelector.Draw(context))
                {
                    bool resetMethod;
                    invokationTargetType = DrawTypeSelector(invokationTargetType, invokation, context, ref changed, out resetMethod);
                    if (resetMethod)
                    {
                        hasMethod = false;
                        hasStaticMethod = false;
                    }
                }
                if (!hasStaticMethod)
                {
                    if (DrawTargetSelector(invokation, context)) changed = true;

                    if (invokation.Target && (invokation.Target is JLObjectValueBase))
                    {
                        var v = ((JLObjectValueBase)invokation.Target).Value;
                        if (v != null)
                        {
                            var newInvokationTargetType = v.GetType();
                            invokation.ExpressionType = newInvokationTargetType.FullName;
                            if (!newInvokationTargetType.IsAssignableFrom(invokationTargetType))
                            {
                                hasMethod = false;
                                hasStaticMethod = false;
                                invokation.MethodAccessor = null;
                            }
                        }
                    }
                }

                if (_typeSelector.Expanded)
                    ReplaceTargetSelector(invokationTargetType, invokation, context);
            }

            #endregion

            #region method

            TypeInfo declaringTypeInfo;
            MethodInfo[] methods;
            string[] methodNames;
            InitializeMethodSelector(invokationTargetType, out declaringTypeInfo, out methods, out methodNames);

            string currentMethodName = null;

            if (hasMethod)
            {
                try
                {
                    currentMethodName = FormatMethodName(declaringTypeInfo.Methods[Array.IndexOf(methods, method)], false, false);
                }
                catch { currentMethodName = method.Name; }
            }

            _methodSelector.CurrentValueIndex = Array.IndexOf(methods, method);
            if (DrawMethodSelector(currentMethodName, invokation, context, ref method, methods, ref hasMethod, ref hasStaticMethod, ref methodData)) changed = true;

            #endregion

            #region arguments

            if (hasMethod && (methodData.Parameters.Count != 0))
            {
                PrefixLabel("Arguments:", true);
                BeginVertical(StylesCache.box);

                MethodInvokationArgumentBase[] args = invokation.ArgumentsAccessor;
                for (int i = 0; i < args.Length; i++)
                {
                    if (methodData.Parameters.Count <= i)
                    {
                        var a = args[i];
                        if (a.Value)
                            JLScriptableHelper.Destroy(a.Value);
                        ArrayUtility.RemoveAt(ref args, i);
                        i--;
                        changed = true;
                    }
                }
                var argumentsCount = args.Length;
                if (!object.ReferenceEquals(_argumentsCache.Method, methodData))
                {
                    if (_argumentsCache.ArgumentDrawers != null)
                        foreach (var drawer in _argumentsCache.ArgumentDrawers)
                            if (drawer != null) drawer.Dispose();
                    if (_argumentsCache.OutVariableDrawers != null)
                        foreach (var drawer in _argumentsCache.OutVariableDrawers)
                            if (drawer != null) drawer.Dispose();
                    _argumentsCache.ArgumentDrawers = new IParameterDrawer[argumentsCount];
                    _argumentsCache.OutVariableDrawers = new IParameterDrawer[argumentsCount];
                    _argumentsCache.Method = methodData;
                }

                for (int i = 0; i < argumentsCount; i++)
                {
                    if (methodData.Parameters.Count <= i)
                    {
                        var a = args[i];
                        if (a.Value)
                            JLScriptableHelper.Destroy(a.Value);
                        ArrayUtility.RemoveAt(ref args, i);
                        i--;
                        changed = true;
                        continue;
                    }
                    var param = methodData.Parameters[i];
                    var pType = param.ParameterType;

                    bool isRef = pType.IsByRef;
                    if (isRef)
                        pType = pType.GetElementType();
                    if (isRef) BeginVertical(StylesCache.box);
                    var arg = args[i];

                    if (param.IsOut)
                    {
                        if (!arg.Value || !(arg.Value is JLNullReferenceBase))
                        {
                            arg.Value = (JLExpression)JLScriptableHelper.ReplaceUnitSubtype(arg.Value, typeof(JLExpression), typeof(JLNullReferenceBase));
                            changed = true;
                        }
                    }
                    else
                    {
                        var argDrawer = _argumentsCache.ArgumentDrawers[i];
                        if (argDrawer == null)
                            _argumentsCache.ArgumentDrawers[i] = argDrawer =
                                InitArgs.Factory.CreateDrawer(new DrawerInitArgs(typeof(JLExpression), param.Name, expressionType: pType), arg.Value, context);
                        if (argDrawer != null && argDrawer.SimpleDraw(context))
                        {
                            changed = true;
                            arg.Value = (JLExpression)argDrawer.Value;
                        }
                    }
                    if (param.IsOut || isRef)
                    {
                        var outDrawer = _argumentsCache.OutVariableDrawers[i];
                        if (outDrawer == null)
                        {
                            _argumentsCache.OutVariableDrawers[i] = outDrawer =
                                InitArgs.Factory.CreateDrawer(new DrawerInitArgs(typeof(SelectedVariableInfoBase), param.IsOut ? ("out " + param.Name) : "Out variable"), arg.OutVariableAccessor, context);
                        }
                        if (outDrawer != null && outDrawer.SimpleDraw(context))
                        {
                            changed = true;
                            arg.OutVariableAccessor = (SelectedVariableInfoBase)outDrawer.Value;
                        }
                    }
                    if (isRef) EndVertical();
                }

                invokation.ArgumentsAccessor = args;

                EndVertical();
            }
            else if (ClearInvokationArguments(invokation)) changed = true;

            #endregion

            return changed;
        }

        struct ArgumentsCacheHolder
        {
            public SerializableMethodBase Method;
            public IParameterDrawer[] ArgumentDrawers;
            public IParameterDrawer[] OutVariableDrawers;
        }

        ArgumentsCacheHolder _argumentsCache;

        private static bool ClearInvokationArguments(MethodInvokationBase invokation)
        {
            bool changed = false;
            if (invokation.ArgumentsAccessor == null)
            {
                invokation.ArgumentsAccessor = new MethodInvokationArgumentBase[0];
                changed = true;
            }
            foreach (var argument in invokation.ArgumentsAccessor)
            {
                changed = true;
                if (argument.Value)
                    JLScriptableHelper.Destroy(argument.Value);
            }
            if (invokation.ArgumentsAccessor.Length != 0)
            {
                invokation.ArgumentsAccessor = new MethodInvokationArgumentBase[0];
                changed = true;
            }
            return changed;
        }

        private static string FormatMethodName(TypeInfo.CompleteMethodInfo methodInfo, bool withReturnType = true, bool parameterTypes = true)
        {
            var sb = new StringBuilder();
            var method = methodInfo.Method;
            if (withReturnType && (method.ReturnType != typeof(void)))
            {
                sb.Append(method.ReturnType.Name);
                sb.Append(" ");
            }
            sb.Append(method.Name);
            if (method.ContainsGenericParameters)
            {
                sb.Append("<");
                var def = method;
                if (!def.IsGenericMethodDefinition)
                    def = def.GetGenericMethodDefinition();
                bool f = true;
                foreach (var parameterInfo in def.GetGenericArguments())
                {
                    if (f)
                        f = false;
                    else
                        sb.Append(",");

                    sb.Append(parameterInfo.Name);
                }
                sb.Append(">");
            }
            sb.Append(method.IsStatic ? "[" : "(");
            bool first = true;
            foreach (var p in methodInfo.Pointer.Parameters)
            {
                if (first)
                    first = false;
                else
                    sb.Append(", ");
                if (parameterTypes)
                {
                    var parameterType = p.ParameterType;
                    if (p.IsOut)
                        sb.Append("out ");
                    else if (parameterType.IsByRef)
                    {
                        sb.Append("ref ");
                    }
                    sb.Append(parameterType.Name);
                    sb.Append(" ");
                }
                sb.Append(p.Name);
            }
            sb.Append(method.IsStatic ? "]" : ")");

            //string r = sb.ToString();
            //if (r.StartsWith("Void ", StringComparison.OrdinalIgnoreCase))
            //   r = sb.Remove(0, "Void ".Length).ToString();
            return sb.ToString();
        }
    }
}