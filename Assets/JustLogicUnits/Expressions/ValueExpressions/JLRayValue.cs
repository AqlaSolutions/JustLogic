using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Ray")]
[UnitUsage(typeof(Ray), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLRayValue : JLExpression
{
    [Parameter]
    public Ray Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
