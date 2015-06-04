using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Blend Mode")]
[UnitFriendlyName("AnimationState.Get Blend Mode")]
[UnitUsage(typeof(AnimationBlendMode), HideExpressionInActionsList = true)]
public class JLAnimationStateGetBlendMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.blendMode;
    }
}
