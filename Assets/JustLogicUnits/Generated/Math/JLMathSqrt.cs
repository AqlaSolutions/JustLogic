using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Sqrt")]
[UnitFriendlyName("Sqrt")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathSqrt : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Sqrt(F.GetResult<System.Single>(context));
    }
}
