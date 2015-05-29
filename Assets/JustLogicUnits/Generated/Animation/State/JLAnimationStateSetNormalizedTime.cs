using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Normalized Time")]
[UnitFriendlyName("AnimationState.Set Normalized Time")]
[UnitUsage(typeof(System.Single))]
public class JLAnimationStateSetNormalizedTime : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.normalizedTime = Value.GetResult<System.Single>(context);
    }
}
