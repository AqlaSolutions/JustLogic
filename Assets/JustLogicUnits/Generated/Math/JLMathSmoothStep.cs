using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/SmoothStep")]
[UnitFriendlyName("SmoothStep")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathSmoothStep : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.SmoothStep(From.GetResult<System.Single>(context), To.GetResult<System.Single>(context), T.GetResult<System.Single>(context));
    }
}
