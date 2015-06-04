using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Frame Rate")]
[UnitFriendlyName("AnimationClip.Get Frame Rate")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationClipGetFrameRate : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationClip opValue = OperandValue.GetResult<AnimationClip>(context);
        return opValue.frameRate;
    }
}
