using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/LerpAngle")]
[UnitFriendlyName("LerpAngle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLerpAngle : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.LerpAngle(A.GetResult<System.Single>(context), B.GetResult<System.Single>(context), T.GetResult<System.Single>(context));
    }
}
