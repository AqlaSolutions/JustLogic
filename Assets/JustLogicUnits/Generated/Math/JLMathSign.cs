using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Sign")]
[UnitFriendlyName("Sign")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathSign : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Sign(F.GetResult<System.Single>(context));
    }
}
