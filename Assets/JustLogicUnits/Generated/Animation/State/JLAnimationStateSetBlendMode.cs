using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Blend Mode")]
[UnitFriendlyName("AnimationState.Set Blend Mode")]
[UnitUsage(typeof(AnimationBlendMode))]
public class JLAnimationStateSetBlendMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AnimationBlendMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.blendMode = Value.GetResult<AnimationBlendMode>(context);
    }
}
