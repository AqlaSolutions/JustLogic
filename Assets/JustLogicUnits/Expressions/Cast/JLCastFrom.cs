using JustLogic.Core;

[UnitUsage(HideExpressionInActionsList = true)]
[UnitMenu("Cast/From")]
public class JLCastFrom : JLExpression
{
    [Parameter]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value.GetAnyResultSafe(context);
    }
}
