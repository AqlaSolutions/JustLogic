using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Set Wrap Mode")]
[UnitFriendlyName("AnimationClip.Set Wrap Mode")]
[UnitUsage(typeof(WrapMode))]
public class JLAnimationClipSetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(WrapMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationClip opValue = OperandValue.GetResult<AnimationClip>(context);
        return opValue.wrapMode = Value.GetResult<WrapMode>(context);
    }
}
