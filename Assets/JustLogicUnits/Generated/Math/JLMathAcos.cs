using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Acos")]
[UnitFriendlyName("Acos")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathAcos : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Acos(F.GetResult<System.Single>(context));
    }
}
