using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/DeltaAngle")]
[UnitFriendlyName("DeltaAngle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathDeltaAngle : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Target;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.DeltaAngle(Current.GetResult<System.Single>(context), Target.GetResult<System.Single>(context));
    }
}
