using JustLogic.Core;

[UnitMenu("Math/Mod")]
[UnitUsage(typeof(float), HideExpressionInActionsList = true)]
public class JLMod : JLExpression
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Devider;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value.GetResult<float>(context) % Devider.GetResult<float>(context);
    }
}
