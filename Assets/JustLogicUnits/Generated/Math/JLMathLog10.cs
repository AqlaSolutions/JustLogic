using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Log10")]
[UnitFriendlyName("Log10")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLog10 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Log10(F.GetResult<System.Single>(context));
    }
}
