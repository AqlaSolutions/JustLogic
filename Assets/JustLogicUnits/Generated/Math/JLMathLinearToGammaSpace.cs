using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/LinearToGammaSpace")]
[UnitFriendlyName("LinearToGammaSpace")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLinearToGammaSpace : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.LinearToGammaSpace(Value.GetResult<System.Single>(context));
    }
}
