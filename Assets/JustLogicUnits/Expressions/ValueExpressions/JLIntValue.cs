
using JustLogic.Core;

[UnitMenu("Value/Int")]
[UnitUsage(typeof(int), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLIntValue : JLExpression
{
    [Parameter]
    public int Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
