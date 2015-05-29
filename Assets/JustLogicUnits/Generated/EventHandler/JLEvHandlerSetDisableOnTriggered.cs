using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("Event/Set Disable On Triggered")]
[UnitFriendlyName("Set Disable On Triggered")]
[UnitUsage(typeof(System.Boolean))]
public class JLEvHandlerSetDisableOnTriggered : JLExpression
{
    [Parameter(ExpressionType = typeof(JustLogicEventHandlerCoreBase))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        JustLogicEventHandlerCoreBase opValue = Target.GetResult<JustLogicEventHandlerCoreBase>(context);
        return opValue.DisableOnTriggered = Value.GetResult<System.Boolean>(context);
    }
}
