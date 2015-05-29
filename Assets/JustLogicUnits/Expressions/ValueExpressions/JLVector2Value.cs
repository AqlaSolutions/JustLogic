using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Vector2")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLVector2Value : JLExpression
{
    [Parameter]
    public Vector2 Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
