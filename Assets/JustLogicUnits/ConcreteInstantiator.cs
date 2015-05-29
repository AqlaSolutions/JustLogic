using System.Reflection;
using UnityEngine;

namespace JustLogic.Core
{
    public class ConcreteInstantiator : Instantiator
    {
        public override SerializableMethodBase CreateSerializableMethodBase(MethodInfo method)
        {
            return new SerializableMethod(method);
        }

        public override MethodInvokationArgumentBase CreateMethodInvokationArgumentBase(JLExpression value, SelectedVariableInfoBase outVariable = null)
        {
            return new MethodInvokationArgument(value, outVariable);
        }

        public override MethodInvokationBase CreateMethodInvokationBase()
        {
            return new MethodInvokation();
        }

        public override SerializedEnumBase CreateSerializedEnumBase()
        {
            return new SerializedEnum();
        }

        public override SelectedVariableInfoBase CreateSelectedVariableInfoBase()
        {
            return new SelectedVariableInfo();
        }

        public override UnityEngine.ScriptableObject CreateScriptable(System.Type type)
        {
            if (type == typeof(JLAndBase)) return ScriptableObject.CreateInstance<JLAnd>();
            if (type == typeof(JLEvaluteBase)) return ScriptableObject.CreateInstance<JLEvalute>();
            if (type == typeof(JLIfBase)) return ScriptableObject.CreateInstance<JLIf>();
            if (type == typeof(JLNullReferenceBase)) return ScriptableObject.CreateInstance<JLNullReference>();
            if (type == typeof(JLPrintRetBase)) return ScriptableObject.CreateInstance<JLPrintRet>();
            if (type == typeof(JLSequenceBase)) return ScriptableObject.CreateInstance<JLSequence>();
            if (type == typeof(JLCompareEventArgumentBase)) return ScriptableObject.CreateInstance<JLCompareEventArgument>();
            if (type == typeof(JLCompareBase)) return ScriptableObject.CreateInstance<JLCompare>();
            if (type == typeof(JLNoopBase)) return ScriptableObject.CreateInstance<JLNoop>();
            if (type == typeof(JLStringValueBase)) return ScriptableObject.CreateInstance<JLStringValue>();
            if (type == typeof(JLEventArgumentBase)) return ScriptableObject.CreateInstance<JLEventArgument>();
            if (type == typeof(JLObjectValueBase)) return ScriptableObject.CreateInstance<JLObjectValue>();
            if (type == typeof(JLCustomScriptAssetBase)) return ScriptableObject.CreateInstance<JLCustomScriptAsset>();
            if (type == typeof(JLCustomExpressionAssetBase)) return ScriptableObject.CreateInstance<JLCustomExpressionAsset>();
            return base.CreateScriptable(type);
        }
    }
}