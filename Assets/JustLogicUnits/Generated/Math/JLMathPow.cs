using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Pow")]
[UnitFriendlyName("Pow")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathPow : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression P;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Pow(F.GetResult<System.Single>(context), P.GetResult<System.Single>(context));
    }
}
