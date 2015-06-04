using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/GammaToLinearSpace")]
[UnitFriendlyName("GammaToLinearSpace")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathGammaToLinearSpace : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.GammaToLinearSpace(Value.GetResult<System.Single>(context));
    }
}
