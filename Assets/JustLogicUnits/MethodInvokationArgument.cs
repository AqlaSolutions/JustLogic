using System;

namespace JustLogic.Core
{
    [Serializable]
    public class MethodInvokationArgument : MethodInvokationArgumentBase
    {
        public MethodInvokationArgument(JLExpression value, SelectedVariableInfoBase outVariable = null) : base(value, outVariable)
        {
        }

        public MethodInvokationArgument()
        {
        }

        public SelectedVariableInfo OutVariable;

        public override SelectedVariableInfoBase OutVariableAccessor { get { return OutVariable; } set { OutVariable = (SelectedVariableInfo)value; } }
    }
}
