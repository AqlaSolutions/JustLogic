using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/RoundToInt")]
[UnitFriendlyName("RoundToInt")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathRoundToInt : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.RoundToInt(F.GetResult<System.Single>(context));
    }
}
