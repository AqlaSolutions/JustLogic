using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Set Wrap Mode")]
[UnitFriendlyName("AnimationClip.Set Wrap Mode")]
[UnitUsage(typeof(UnityEngine.WrapMode))]
public class JLAnimationClipSetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.WrapMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.wrapMode = Value.GetResult<UnityEngine.WrapMode>(context);
    }
}
