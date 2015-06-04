using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Clamp2 (int)")]
[UnitFriendlyName("Clamp2 (int)")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathClamp2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Min;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Max;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Clamp(Value.GetResult<System.Int32>(context), Min.GetResult<System.Int32>(context), Max.GetResult<System.Int32>(context));
    }
}
