using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("Event/Get Triggered Counter")]
[UnitFriendlyName("Get Triggered Counter")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLEvHandlerGetTriggeredCounter : JLExpression
{
    [Parameter(ExpressionType = typeof(JustLogicEventHandlerCoreBase))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        JustLogicEventHandlerCoreBase opValue = OperandValue.GetResult<JustLogicEventHandlerCoreBase>(context);
        return opValue.TriggeredCounter;
    }
}
