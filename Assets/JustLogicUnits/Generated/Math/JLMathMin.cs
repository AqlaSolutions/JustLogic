using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Min (float[])")]
[UnitFriendlyName("Min (float[])")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathMin : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Min(Values.GetResult<System.Single>(context));
    }
}
