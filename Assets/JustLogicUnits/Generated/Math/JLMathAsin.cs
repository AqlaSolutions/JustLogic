using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Asin")]
[UnitFriendlyName("Asin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathAsin : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Asin(F.GetResult<System.Single>(context));
    }
}
