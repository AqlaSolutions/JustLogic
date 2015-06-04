using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/PerlinNoise")]
[UnitFriendlyName("PerlinNoise")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathPerlinNoise : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression X;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Y;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.PerlinNoise(X.GetResult<System.Single>(context), Y.GetResult<System.Single>(context));
    }
}
