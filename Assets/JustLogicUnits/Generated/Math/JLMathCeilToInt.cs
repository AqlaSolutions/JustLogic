using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/CeilToInt")]
[UnitFriendlyName("CeilToInt")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathCeilToInt : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.CeilToInt(F.GetResult<System.Single>(context));
    }
}
