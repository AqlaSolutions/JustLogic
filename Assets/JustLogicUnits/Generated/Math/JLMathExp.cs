using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Exp")]
[UnitFriendlyName("Exp")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathExp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Power;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Exp(Power.GetResult<System.Single>(context));
    }
}
