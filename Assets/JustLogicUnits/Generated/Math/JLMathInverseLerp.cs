using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/InverseLerp")]
[UnitFriendlyName("InverseLerp")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathInverseLerp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.InverseLerp(From.GetResult<System.Single>(context), To.GetResult<System.Single>(context), Value.GetResult<System.Single>(context));
    }
}
