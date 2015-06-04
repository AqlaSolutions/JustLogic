using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Lerp (float)")]
[UnitFriendlyName("Lerp (float)")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLerp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Lerp;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Lerp(From.GetResult<System.Single>(context), To.GetResult<System.Single>(context), Lerp.GetResult<System.Single>(context));
    }
}
