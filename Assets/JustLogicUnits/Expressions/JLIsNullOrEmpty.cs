using JustLogic.Core;

[UnitUsage(HideExpressionInActionsList = true)]
[UnitMenu("String/Is Null Or Empty")]
public class JLIsNullOrEmpty : JLBoolExpression
{
    [Parameter(ExpressionType = typeof(string))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return string.IsNullOrEmpty(Value.GetAnyResultSafe(context) as string);
    }
}
