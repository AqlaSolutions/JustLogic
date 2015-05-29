using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Tan")]
[UnitFriendlyName("Tan")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathTan : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Mathf.Tan(F.GetResult<System.Single>(context));
    }
}
