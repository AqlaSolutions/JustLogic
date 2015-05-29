using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("Event/Reset Triggered Counter")]
[UnitFriendlyName("Reset Triggered Counter")]
public class JLEvHandlerResetTriggeredCounter : JLAction
{
    [Parameter(ExpressionType = typeof(JustLogicEventHandlerCoreBase))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        JustLogicEventHandlerCoreBase opValue = OperandValue.GetResult<JustLogicEventHandlerCoreBase>(context);
        opValue.ResetTriggeredCounter();
        return null;
    }
}
