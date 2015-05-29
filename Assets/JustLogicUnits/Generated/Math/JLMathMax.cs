using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Max (float[])")]
[UnitFriendlyName("Max (float[])")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathMax : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Max(Values.GetResult<System.Single>(context));
    }
}
