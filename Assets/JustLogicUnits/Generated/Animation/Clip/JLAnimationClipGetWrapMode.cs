using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Wrap Mode")]
[UnitFriendlyName("AnimationClip.Get Wrap Mode")]
[UnitUsage(typeof(WrapMode), HideExpressionInActionsList = true)]
public class JLAnimationClipGetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationClip opValue = OperandValue.GetResult<AnimationClip>(context);
        return opValue.wrapMode;
    }
}
