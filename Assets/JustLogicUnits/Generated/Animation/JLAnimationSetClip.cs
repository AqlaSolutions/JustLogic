using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Set Clip")]
[UnitFriendlyName("Animation.Set Clip")]
[UnitUsage(typeof(AnimationClip))]
public class JLAnimationSetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.clip = Value.GetResult<AnimationClip>(context);
    }
}
