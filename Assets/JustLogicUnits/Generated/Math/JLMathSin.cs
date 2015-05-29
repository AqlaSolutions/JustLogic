using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Sin")]
[UnitFriendlyName("Sin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathSin : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Sin(F.GetResult<System.Single>(context));
    }
}
