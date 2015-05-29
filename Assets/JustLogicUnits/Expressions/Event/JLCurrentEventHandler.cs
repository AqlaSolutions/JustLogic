#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("Event/Current Handler")]
[UnitUsage(typeof(JustLogicEventHandlerCoreBase), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLCurrentEventHandler : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return context.CurrentEvent != null ? context.CurrentEvent.Handler : null;
    }
}

#endif
