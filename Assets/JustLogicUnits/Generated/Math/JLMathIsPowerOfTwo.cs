using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/IsPowerOfTwo")]
[UnitFriendlyName("IsPowerOfTwo")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLMathIsPowerOfTwo : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.IsPowerOfTwo(Value.GetResult<System.Int32>(context));
    }
}
