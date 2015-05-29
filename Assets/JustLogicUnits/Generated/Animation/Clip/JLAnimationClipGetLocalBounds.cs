using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Local Bounds")]
[UnitFriendlyName("AnimationClip.Get Local Bounds")]
[UnitUsage(typeof(UnityEngine.Bounds), HideExpressionInActionsList = true)]
public class JLAnimationClipGetLocalBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.localBounds;
    }
}
