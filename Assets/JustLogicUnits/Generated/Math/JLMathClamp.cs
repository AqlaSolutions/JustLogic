using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Clamp (float)")]
[UnitFriendlyName("Clamp (float)")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathClamp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Min;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Max;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Clamp(Value.GetResult<System.Single>(context), Min.GetResult<System.Single>(context), Max.GetResult<System.Single>(context));
    }
}
