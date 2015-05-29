using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Repeat")]
[UnitFriendlyName("Repeat")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathRepeat : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Repeat(T.GetResult<System.Single>(context), Length.GetResult<System.Single>(context));
    }
}
