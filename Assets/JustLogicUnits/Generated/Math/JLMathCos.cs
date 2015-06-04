using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Cos")]
[UnitFriendlyName("Cos")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathCos : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Cos(F.GetResult<System.Single>(context));
    }
}
