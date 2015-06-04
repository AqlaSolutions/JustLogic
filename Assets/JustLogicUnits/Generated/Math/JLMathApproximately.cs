using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Approximately")]
[UnitFriendlyName("Approximately")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLMathApproximately : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Approximately(A.GetResult<System.Single>(context), B.GetResult<System.Single>(context));
    }
}
