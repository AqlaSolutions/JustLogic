using System;
using System.Collections.Generic;
using System.Reflection;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class MethodInvokationBase
    {
        public abstract SerializableMethodBase MethodAccessor { get; set; }
        public JLExpression Target;

        /// <summary>
        /// Editor only
        /// </summary>
        public string ExpressionType;

        void OnEnable()
        {
            if (string.IsNullOrEmpty(ExpressionType))
                ExpressionType = typeof(UnityEngine.Object).FullName;
        }

        public abstract MethodInvokationArgumentBase[] ArgumentsAccessor { get; set; }
        public string ReturnType;

        public string[] TypeArguments;

        public void SetMethod(MethodInfo method, Action<MethodInvokationArgumentBase> destroyArgumentFunc = null)
        {
            MethodAccessor = method;
            ReturnType = method.ReturnType.FullName;
            int parametersCount = method.GetParameters().Length;
            if (ArgumentsAccessor == null)
            {
                ArgumentsAccessor = new MethodInvokationArgumentBase[parametersCount];
                for (int i = 0; i < ArgumentsAccessor.Length; i++)
                    ArgumentsAccessor[i] = Library.Instantiator.CreateMethodInvokationArgumentBase(null);
            }
            else
            {
                var lst = new List<MethodInvokationArgumentBase>(ArgumentsAccessor);
                while (lst.Count < parametersCount)
                    lst.Add(Library.Instantiator.CreateMethodInvokationArgumentBase(null));
                while (lst.Count > parametersCount)
                {
                    if (destroyArgumentFunc != null)
                        destroyArgumentFunc(lst[lst.Count - 1]);
                    lst.RemoveAt(lst.Count - 1);
                }
                ArgumentsAccessor = lst.ToArray();
            }

            TypeArguments = new string[SerializableMethodBase.GetTypeParametersCount(method)];
        }

        MethodInfo _methodCache;
        ParameterInfo[] _parametersCache;
        TypeInfo _staticTypeCache;

        public object Invoke(IExecutionContext context)
        {
            object target = (Target && !(Target is JLNullReferenceBase)) ? Target.GetAnyResultSafe(context) : null;
            TypeInfo type = (target != null)
                ? (TypeInfo)(target.GetType())
                : (_staticTypeCache ?? (_staticTypeCache = MethodAccessor.DeclaringType));

            MethodInfo m = _methodCache;
            if (m == null)
            {
                _methodCache = m = GetMethodInfo(m, type);
                _parametersCache = m.GetParameters();
            }


            var parameters = new object[ArgumentsAccessor.Length];
            for (int i = 0; i < ArgumentsAccessor.Length; i++)
                parameters[i] = JLExpressionExtensions.ConvertType(ArgumentsAccessor[i].Value.GetAnyResultSafe(context), _parametersCache[i].ParameterType, context);

            object r = m.Invoke(m.IsStatic ? null : target, parameters);
            for (int i = 0; i < ArgumentsAccessor.Length; i++)
            {
                context.GetVariable(ArgumentsAccessor[i].OutVariableAccessor).Value = parameters[i];
            }
            return r;
        }

        private MethodInfo GetMethodInfo(MethodInfo m, TypeInfo type)
        {
            m = type.TryLookupMethod(MethodAccessor).Method;
            if (TypeArguments.Length != 0)
            {
                var pars = new Type[TypeArguments.Length];
                for (int i = 0; i < TypeArguments.Length; i++)
                    pars[i] = Library.FindType(TypeArguments[i]);
                m = m.MakeGenericMethod(pars);
            }
            return m;
        }
    }
}