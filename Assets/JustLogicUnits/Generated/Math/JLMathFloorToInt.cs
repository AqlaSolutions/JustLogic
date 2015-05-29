using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/FloorToInt")]
[UnitFriendlyName("FloorToInt")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathFloorToInt : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.FloorToInt(F.GetResult<System.Single>(context));
    }
}
