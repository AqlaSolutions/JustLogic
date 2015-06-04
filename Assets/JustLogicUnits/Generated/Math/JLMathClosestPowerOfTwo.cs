using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/ClosestPowerOfTwo")]
[UnitFriendlyName("ClosestPowerOfTwo")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathClosestPowerOfTwo : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.ClosestPowerOfTwo(Value.GetResult<System.Int32>(context));
    }
}
