using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Set Local Bounds")]
[UnitFriendlyName("AnimationClip.Set Local Bounds")]
[UnitUsage(typeof(Bounds))]
public class JLAnimationClipSetLocalBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Bounds))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationClip opValue = OperandValue.GetResult<AnimationClip>(context);
        return opValue.localBounds = Value.GetResult<Bounds>(context);
    }
}
