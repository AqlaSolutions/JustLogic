using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Floor")]
[UnitFriendlyName("Floor")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathFloor : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression F;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Floor(F.GetResult<System.Single>(context));
    }
}
