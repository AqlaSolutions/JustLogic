using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/MoveTowardsAngle")]
[UnitFriendlyName("MoveTowardsAngle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathMoveTowardsAngle : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.MoveTowardsAngle(Current.GetResult<System.Single>(context), Target.GetResult<System.Single>(context), MaxDelta.GetResult<System.Single>(context));
    }
}
