using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/NextPowerOfTwo")]
[UnitFriendlyName("NextPowerOfTwo")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathNextPowerOfTwo : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.NextPowerOfTwo(Value.GetResult<System.Int32>(context));
    }
}
