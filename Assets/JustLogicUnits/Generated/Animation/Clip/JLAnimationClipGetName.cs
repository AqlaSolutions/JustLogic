using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Name")]
[UnitFriendlyName("AnimationClip.Get Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAnimationClipGetName : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationClip opValue = OperandValue.GetResult<AnimationClip>(context);
        return opValue.name;
    }
}
