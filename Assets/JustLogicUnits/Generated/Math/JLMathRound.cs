using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Round")]
[UnitFriendlyName("Round")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathRound : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Round(F.GetResult<System.Single>(context));
    }
}
