using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Color")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLColorValue : JLExpression
{
    [Parameter]
    public Color Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
