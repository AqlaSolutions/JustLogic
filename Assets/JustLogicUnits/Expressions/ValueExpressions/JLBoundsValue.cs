using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Bounds")]
[UnitUsage(typeof(Bounds), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLBoundsValue : JLExpression
{
    [Parameter]
    public Bounds Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
