using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Color32")]
[UnitUsage(typeof(Color32), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLColor32Value : JLExpression
{
    [Parameter]
    public Color Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Color32)Value;
    }
}
