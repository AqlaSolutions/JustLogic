using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("Event/Get Disable On Triggered")]
[UnitFriendlyName("Get Disable On Triggered")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLEvHandlerGetDisableOnTriggered : JLExpression
{
    [Parameter(ExpressionType = typeof(JustLogicEventHandlerCoreBase))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        JustLogicEventHandlerCoreBase opValue = OperandValue.GetResult<JustLogicEventHandlerCoreBase>(context);
        return opValue.DisableOnTriggered;
    }
}
