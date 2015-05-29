using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Log")]
[UnitFriendlyName("Log")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathLog : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Log(F.GetResult<System.Single>(context));
    }
}
