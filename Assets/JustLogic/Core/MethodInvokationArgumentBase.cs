using System;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class MethodInvokationArgumentBase
    {
        public JLExpression Value;
        public abstract SelectedVariableInfoBase OutVariableAccessor { get; set; }

        public MethodInvokationArgumentBase(JLExpression value, SelectedVariableInfoBase outVariable = null)
        {
            Value = value;
            OutVariableAccessor = outVariable;
        }

        public MethodInvokationArgumentBase()
        {
        }
    }
}