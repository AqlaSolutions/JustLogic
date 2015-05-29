using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Gamma")]
[UnitFriendlyName("Gamma")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathGamma : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Absmax;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Gamma;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Gamma(Value.GetResult<System.Single>(context), Absmax.GetResult<System.Single>(context), Gamma.GetResult<System.Single>(context));
    }
}
