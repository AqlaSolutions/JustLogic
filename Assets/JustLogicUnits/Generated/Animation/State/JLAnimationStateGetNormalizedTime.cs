using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Normalized Time")]
[UnitFriendlyName("AnimationState.Get Normalized Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationStateGetNormalizedTime : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.normalizedTime;
    }
}
