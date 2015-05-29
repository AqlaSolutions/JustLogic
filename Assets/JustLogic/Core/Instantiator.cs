using System;
using System.Reflection;
using UnityEngine;

namespace JustLogic.Core
{
    public abstract class Instantiator
    {
        public abstract SerializableMethodBase CreateSerializableMethodBase(MethodInfo method);
        public abstract MethodInvokationArgumentBase CreateMethodInvokationArgumentBase(JLExpression value, SelectedVariableInfoBase outVariable = null);
        public abstract MethodInvokationBase CreateMethodInvokationBase();
        public abstract SerializedEnumBase CreateSerializedEnumBase();
        public abstract SelectedVariableInfoBase CreateSelectedVariableInfoBase();

        public T CreateScriptable<T>() where T : ScriptableObject
        {
            return (T)CreateScriptable(typeof(T));
        }

        public virtual ScriptableObject CreateScriptable(Type type)
        {
            return ScriptableObject.CreateInstance(type);
        }

        public virtual ScriptableObject CreateScriptable(string classname)
        {
            return ScriptableObject.CreateInstance(classname);
        }

    }
}