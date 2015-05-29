using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Atan")]
[UnitFriendlyName("Atan")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathAtan : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Atan(F.GetResult<System.Single>(context));
    }
}
