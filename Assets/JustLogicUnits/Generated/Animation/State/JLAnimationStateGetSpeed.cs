using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Speed")]
[UnitFriendlyName("AnimationState.Get Speed")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationStateGetSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.speed;
    }
}
