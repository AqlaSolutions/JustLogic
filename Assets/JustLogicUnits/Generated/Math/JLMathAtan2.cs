using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Atan2")]
[UnitFriendlyName("Atan2")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathAtan2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Y;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression X;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Atan2(Y.GetResult<System.Single>(context), X.GetResult<System.Single>(context));
    }
}
