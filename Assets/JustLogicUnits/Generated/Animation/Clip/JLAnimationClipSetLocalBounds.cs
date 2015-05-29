using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Set Local Bounds")]
[UnitFriendlyName("AnimationClip.Set Local Bounds")]
[UnitUsage(typeof(UnityEngine.Bounds))]
public class JLAnimationClipSetLocalBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Bounds))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.localBounds = Value.GetResult<UnityEngine.Bounds>(context);
    }
}
