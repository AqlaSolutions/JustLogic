using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Abs (float)")]
[UnitFriendlyName("Abs (float)")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathAbs : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Abs(Value.GetResult<System.Single>(context));
    }
}
