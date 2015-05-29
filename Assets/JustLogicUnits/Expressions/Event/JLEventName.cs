#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("Event/Name")]
[UnitUsage(typeof(string),HideExpressionInActionsList = true)]
public class JLEventName : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return context.CurrentEvent != null ? context.CurrentEvent.EventInfo.Name : string.Empty;
    }
}

#endif
