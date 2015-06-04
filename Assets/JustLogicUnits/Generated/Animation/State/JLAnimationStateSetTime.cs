using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Time")]
[UnitFriendlyName("AnimationState.Set Time")]
[UnitUsage(typeof(System.Single))]
public class JLAnimationStateSetTime : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.time = Value.GetResult<System.Single>(context);
    }
}
