using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Quaternion")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLQuaternionValue : JLExpression
{
    [Parameter]
    public Quaternion Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }

}
