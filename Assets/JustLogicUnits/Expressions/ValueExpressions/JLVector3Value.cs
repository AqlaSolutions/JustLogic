using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Vector3")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLVector3Value : JLExpression
{
    [Parameter]
    public Vector3 Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
