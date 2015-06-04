using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace JustLogic.Core
{
    public class TypeInfo
    {

        public override string ToString()
        {
            return Type.ToString();
        }

        static readonly Dictionary<Type, TypeInfo> Cache = new Dictionary<Type, TypeInfo>();



        public static implicit operator Type(TypeInfo type)
        {
            if (type == null) return null;
            return type.Type;
        }

        public static implicit operator TypeInfo(Type type)
        {
            if (type == null) return null;
            TypeInfo el;
            lock (Cache)
            {
                if (Cache.TryGetValue(type, out el))
                    return el;
            }

            el = new TypeInfo(type);

            lock (Cache)
                Cache[type] = el;

            return el;

        }

        public Type Type { get; private set; }
        public UnitParameters JustLogicParameters { get { Initialize(); return _justLogicParameters; } }
        public IList<UnitParameter> JustLogicParametersList
        {
            get
            {
                Initialize();
                return _justLogicParameters != null ? _justLogicParameters.List : EmptyUnitParametersList;
            }
        }
        static readonly UnitParameter[] EmptyUnitParametersList = new UnitParameter[0];

        bool _isUnityObject;
        public bool IsUnityObject { get { Initialize(); return _isUnityObject; } }

        public bool IsAssignableTo(UnitParameter parameter)
        {
            if (!parameter.Type.IsAssignableFrom(Type))
                return false;
            if (IsUnityObject && typeof(JLUnitBase).IsAssignableFrom(Type) && !typeof(JLUnitBase).IsAssignableFrom(parameter.Type))
                return false;
            if (!IsUnityObject || !typeof(JLExpression).IsAssignableFrom(Type) || (UnitUsage == null) || (parameter.ExpressionType == null))
                return true;
            return IsExpressionResultAssignableTo(parameter.ExpressionType);
        }

        public bool IsExpressionResultAssignableTo(TypeInfo parameterExpressionType)
        {
            if (!typeof(JLExpression).IsAssignableFrom(Type))
                return false;
            Initialize();

            if ((UnitUsage == null) || (UnitUsage.ExpressionReturnTypeInfo == null)) return true;

            TypeInfo paramType = parameterExpressionType.MainAliasType,
                myReturnType = (UnitUsage.ExpressionReturnTypeInfo ?? this).MainAliasType;

            return (myReturnType == paramType) || (!UnitUsage.StrictApplicability && paramType.Type.IsAssignableFrom(myReturnType))
                      || (UnitUsage.AllowBaseAssignability && myReturnType.Type.IsAssignableFrom(paramType));

        }
        
        public static int GetDifference(Type baseType, Type concreteType)
        {
            int d = 0;
            while ((concreteType != baseType) && (concreteType != typeof(object)) && (concreteType != null))
            {
                concreteType = concreteType.BaseType;
                d++;
            }
            return d;
        }

        public static bool operator ==(TypeInfo t1, Type t2)
        {
            if (ReferenceEquals(t1, null))
            {
                if (ReferenceEquals(t2, null)) return true;
                return false;
            }
            return t1.Type == t2;
        }

        public static bool operator !=(TypeInfo t1, Type t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            {
                var t = obj as TypeInfo;
                if (!ReferenceEquals(t, null))
                    return Type == t.Type;
            }

            {
                var t = obj as Type;
                if (!ReferenceEquals(t, null))
                    return Type == t;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        TypeInfo _mainAliasType;

        /// <summary>
        /// Если несколько типов выражений можно трактовать как один, то он будет здесь для таких заменяемых типов
        /// </summary>
        public TypeInfo MainAliasType { get { Initialize(); return _mainAliasType; } }

        public UnitUsageAttribute UnitUsage { get { Initialize(); return _unitUsage; } }

        string _friendlyName;
        public string FriendlyName { get { Initialize(); return _friendlyName; } }

        public string[] UnitMenus { get { Initialize(); return _unitMenus; } }

        TypeInfo _unitBaseType;
        public Type UnitBaseType { get { Initialize(); return _unitBaseType; } }

        readonly object _initLock = new object();
        volatile bool _inited;

        public void Initialize()
        {
            if (!_inited)
                lock (_initLock)
                {
                    if (_inited) return;

                    {
                        var alias = TypeKey.GetMainAlias(Type);
                        if (alias != Type)
                            _mainAliasType = alias;
                        else
                            _mainAliasType = this;
                    }

                    _justLogicParameters = UnitParameters.Get(Type);
                    _unitUsage = (UnitUsageAttribute)Attribute.GetCustomAttribute(Type, typeof(UnitUsageAttribute), true);

                    {
                        var attrs = Attribute.GetCustomAttributes(Type, typeof(UnitMenuAttribute));
                        _unitMenus = new string[attrs.Length];
                        for (int i = 0; i < attrs.Length; i++)
                            _unitMenus[i] = ((UnitMenuAttribute)attrs[i]).Menu;
                    }

                    var methods = Type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                    var lstMethods = new List<CompleteMethodInfo>();
                    for (int i = 0; i < methods.Length; i++)
                    {
                        var methodInfo = methods[i];
                        if (methodInfo.ContainsGenericParameters || methodInfo.IsGenericMethodDefinition) continue;
                        SerializableMethodBase ptr = methodInfo;
                        lstMethods.Add(_methods[ptr] = new CompleteMethodInfo(methodInfo, ptr));

                    }
                    _methodsList = new ReadOnlyCollection<CompleteMethodInfo>(lstMethods);
                    _fields = Type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                    var friendlyAttr = (UnitFriendlyNameAttribute)Attribute.GetCustomAttribute(Type, typeof(UnitFriendlyNameAttribute));
                    _friendlyName = friendlyAttr != null ? friendlyAttr.Name : GenerateTypeFriendlyName(Type.GetSimpleName());

                    _isUnityObject = typeof(UnityEngine.Object).IsAssignableFrom(Type);

                    _conversationsTo = new Dictionary<Type, MethodInfo>();
                    _conversationsFrom = new Dictionary<Type, MethodInfo>();
                    foreach (var methodInfo in _methodsList)
                    {
                        if (methodInfo.Method.IsSpecialName && methodInfo.Method.IsStatic
                            && (methodInfo.Method.Name == "op_Implicit") || (methodInfo.Method.Name == "op_Explicit"))
                        {
                            var pars = methodInfo.Method.GetParameters();
                            if (pars.Length == 1)
                            {
                                if (pars[0].ParameterType == Type)
                                    _conversationsTo.Add(methodInfo.Method.ReturnType, methodInfo);
                                else if (methodInfo.Method.ReturnType == Type)
                                    _conversationsFrom.Add(pars[0].ParameterType, methodInfo);
                            }

                        }
                    }
                    if (Type != typeof(JLUnitBase) && typeof(JLUnitBase).IsAssignableFrom(Type))
                    {
                        Type unitBaseType = Type;
                        while (unitBaseType.BaseType != typeof(JLUnitBase))
                            unitBaseType = unitBaseType.BaseType;
                        _unitBaseType = unitBaseType;
                    }
                    _inited = true;
                }
        }

        static Dictionary<Type, MethodInfo> _conversationsTo;
        static Dictionary<Type, MethodInfo> _conversationsFrom;

        public MethodInfo TryGetConversationTo(Type other)
        {
            Initialize();
            MethodInfo r;
            if (_conversationsTo.TryGetValue(other, out r)) return r;
            int bases = int.MaxValue;
            foreach (var kv in _conversationsTo)
            {
                if (other.IsAssignableFrom(kv.Key))
                {
                    int newBases = GetTypeBasesCount(kv.Key);
                    if (newBases > bases)
                    {
                        bases = newBases;
                        r = kv.Value;
                    }
                }
            }
            return r;
        }

        public MethodInfo TryGetConversationFrom(Type other)
        {
            Initialize();
            MethodInfo r;
            if (_conversationsFrom.TryGetValue(other, out r)) return r;
            int bases = int.MaxValue;
            foreach (var kv in _conversationsFrom)
            {
                if (kv.Key.IsAssignableFrom(other))
                {
                    int newBases = GetTypeBasesCount(kv.Key);
                    if (newBases > bases)
                    {
                        bases = newBases;
                        r = kv.Value;
                    }
                }
            }
            return r;
        }

        static int GetTypeBasesCount(Type type)
        {
            int c = 0;
            while ((type != typeof(object)) && (type != null))
            {
                type = type.BaseType;
                c++;
            }
            return c;
        }

        public static string GenerateTypeFriendlyName(string name)
        {
            name = name.TrimStart('_');

            // remove "JL" prefix
            if ((name.Length >= 4) && name.StartsWith("JL", StringComparison.Ordinal)
                && (char.IsUpper(name[2]))
                && (!char.IsUpper(name[3])))
                name = name.Remove(0, 2);
            return GenerateMemberFriendlyName(name);
        }

        public static string GenerateMemberFriendlyName(string name)
        {
            name = name.TrimStart('_');
            if (name.Length == 0) return string.Empty;
            var r = new StringBuilder();
            r.Append(char.ToUpper(name[0]));
            bool prevUpper = true;
            bool prevUnderline = false;
            if (name.Length > 1)
                foreach (var c in name.Substring(1))
                {
                    if (c == '_')
                    {
                        prevUnderline = true;
                        continue;
                    }
                    var isUpper = char.IsUpper(c) || prevUnderline;
                    if ((r.Length != 0) && (prevUnderline || (isUpper && !prevUpper)))
                        r.Append(" ");
                    r.Append(prevUnderline ? char.ToUpper(c) : c);
                    prevUpper = isUpper;
                    prevUnderline = false;
                }
            return r.ToString();
        }

        private TypeInfo(Type type)
        {
            Type = type;
        }

        readonly Dictionary<SerializableMethodBase, CompleteMethodInfo> _methods = new Dictionary<SerializableMethodBase, CompleteMethodInfo>();
        private UnitParameters _justLogicParameters;
        private UnitUsageAttribute _unitUsage;
        private string[] _unitMenus;
        private IList<CompleteMethodInfo> _methodsList;
        private IList<FieldInfo> _fields;
        public IList<CompleteMethodInfo> Methods { get { Initialize(); return _methodsList; } }
        public IList<FieldInfo> Fields { get { Initialize(); return _fields; } }
        
        /// <tocexclude />
        public struct CompleteMethodInfo
        {
            public MethodInfo Method { get; private set; }
            public SerializableMethodBase Pointer { get; private set; }

            public override bool Equals(object obj)
            {
                if (!(obj is CompleteMethodInfo)) return false;
                var o = (CompleteMethodInfo)obj;
                return Method.Equals(o.Method);
            }

            public override int GetHashCode()
            {
                return Method.GetHashCode();
            }

            public CompleteMethodInfo(MethodInfo method, SerializableMethodBase pointer)
                : this()
            {
                Method = method;
                Pointer = pointer;
            }

            public static implicit operator MethodInfo(CompleteMethodInfo info)
            {
                if (!info.Pointer.IsValid)
                    return null;
                return info.Method;
            }
        }

        public CompleteMethodInfo TryLookupMethod(SerializableMethodBase pointer)
        {
            Initialize();
            CompleteMethodInfo r;
            _methods.TryGetValue(pointer, out r);
            return r;
        }
    }

    public static class JLTypeExtensions
    {
        /// <summary>
        /// Returns full type name
        /// </summary>
        public static string ToCSharpString(this Type type)
        {
            if ((type == null) || (type == typeof(void))) return "void";
            if (type == typeof(object)) return "object";
            string start = string.Empty;
            Type container = type;
            while (container.DeclaringType != null)
            {
                container = container.DeclaringType;
                start = (container.IsGenericType ? GetSimpleName(container) : container.Name) + "." + start;

            }
            if (!string.IsNullOrEmpty(container.Namespace))
                start = container.Namespace + "." + start;
            if (type.IsGenericType)
            {
                var sb = new StringBuilder(start + GetSimpleName(type) + "<");
                var args = type.GetGenericArguments();
                for (int i = 0; i < args.Length; i++)
                {
                    var arg = args[i];
                    if (i != 0) sb.Append(", ");
                    sb.Append(ToCSharpString(arg));
                }
                sb.Append(">");
                return sb.ToString();
            }
            else return start + type.Name;
        }

        /// <summary>
        /// Returns short type name without generic arguments
        /// </summary>
        public static string GetSimpleName(this Type type)
        {
            string name = type.Name;
            int index = name.IndexOf("`", StringComparison.Ordinal);
            if (index != -1) name = name.Remove(index);
            return name;
        }

    }
}