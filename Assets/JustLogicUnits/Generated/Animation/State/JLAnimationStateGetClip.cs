using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Clip")]
[UnitFriendlyName("AnimationState.Get Clip")]
[UnitUsage(typeof(AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationStateGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.clip;
    }
}
