using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Abs (int)")]
[UnitFriendlyName("Abs (int)")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathAbs2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Abs(Value.GetResult<System.Int32>(context));
    }
}
