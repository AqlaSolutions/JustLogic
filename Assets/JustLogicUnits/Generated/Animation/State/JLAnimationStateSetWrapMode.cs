using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Wrap Mode")]
[UnitFriendlyName("AnimationState.Set Wrap Mode")]
[UnitUsage(typeof(WrapMode))]
public class JLAnimationStateSetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(WrapMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.wrapMode = Value.GetResult<WrapMode>(context);
    }
}
