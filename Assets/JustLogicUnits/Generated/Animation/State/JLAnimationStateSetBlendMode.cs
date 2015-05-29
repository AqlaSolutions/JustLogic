using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Blend Mode")]
[UnitFriendlyName("AnimationState.Set Blend Mode")]
[UnitUsage(typeof(UnityEngine.AnimationBlendMode))]
public class JLAnimationStateSetBlendMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimationBlendMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.blendMode = Value.GetResult<UnityEngine.AnimationBlendMode>(context);
    }
}
