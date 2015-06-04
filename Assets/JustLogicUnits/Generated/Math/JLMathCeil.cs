using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Ceil")]
[UnitFriendlyName("Ceil")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathCeil : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Ceil(F.GetResult<System.Single>(context));
    }
}
