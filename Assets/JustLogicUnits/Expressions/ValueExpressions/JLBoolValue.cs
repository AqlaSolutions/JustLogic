
using JustLogic.Core;

[UnitMenu("Value/Bool")]
[UnitUsage(typeof(bool), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLBoolValue : JLExpression
{
    [Parameter]
    public bool Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
