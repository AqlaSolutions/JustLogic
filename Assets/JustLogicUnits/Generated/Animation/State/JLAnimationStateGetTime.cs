using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Time")]
[UnitFriendlyName("AnimationState.Get Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationStateGetTime : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.time;
    }
}
