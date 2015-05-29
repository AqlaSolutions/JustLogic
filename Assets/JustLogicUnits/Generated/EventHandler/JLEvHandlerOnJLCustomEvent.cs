#if !JUSTLOGIC_FREE
using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("Event/On JLCustom Event")]
[UnitFriendlyName("On JLCustom Event")]
public class JLEvHandlerOnJLCustomEvent : JLAction
{
    [Parameter(ExpressionType = typeof(JustLogicEventHandlerCoreBase))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Argument;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        JustLogicEventHandlerCoreBase opValue = OperandValue.GetResult<JustLogicEventHandlerCoreBase>(context);
        opValue.SendMessage("OnJLCustomEvent", Argument.GetResult<object>(context));
        return null;
    }
}

#endif
