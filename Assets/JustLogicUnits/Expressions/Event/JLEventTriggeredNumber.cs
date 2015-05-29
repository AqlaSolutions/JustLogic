#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("Event/Current Triggered Number")]
[UnitUsage(typeof(int), HideExpressionInActionsList = true)]
public class JLEventTriggeredNumber : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return context.CurrentEvent != null ? context.CurrentEvent.Counter : 0;
    }
}

#endif
