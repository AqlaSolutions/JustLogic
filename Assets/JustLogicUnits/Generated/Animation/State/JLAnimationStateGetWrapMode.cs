using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Wrap Mode")]
[UnitFriendlyName("AnimationState.Get Wrap Mode")]
[UnitUsage(typeof(WrapMode), HideExpressionInActionsList = true)]
public class JLAnimationStateGetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.wrapMode;
    }
}
