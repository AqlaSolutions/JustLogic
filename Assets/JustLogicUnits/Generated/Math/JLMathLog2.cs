using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/LogX")]
[UnitFriendlyName("LogX")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLog2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression P;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Log(Value.GetResult<System.Single>(context), P.GetResult<System.Single>(context));
    }
}
