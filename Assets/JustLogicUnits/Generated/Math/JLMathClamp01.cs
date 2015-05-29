using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Clamp01")]
[UnitFriendlyName("Clamp01")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathClamp01 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Clamp01(Value.GetResult<System.Single>(context));
    }
}
