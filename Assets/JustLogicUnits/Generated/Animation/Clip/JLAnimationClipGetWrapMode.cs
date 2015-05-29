using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Wrap Mode")]
[UnitFriendlyName("AnimationClip.Get Wrap Mode")]
[UnitUsage(typeof(UnityEngine.WrapMode), HideExpressionInActionsList = true)]
public class JLAnimationClipGetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.wrapMode;
    }
}
