
using JustLogic.Core;

[UnitMenu("Value/Float")]
[UnitUsage(typeof(float), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLFloatValue : JLExpression
{
    [Parameter]
    public float Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
