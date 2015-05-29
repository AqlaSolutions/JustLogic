using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Normalized Speed")]
[UnitFriendlyName("AnimationState.Set Normalized Speed")]
[UnitUsage(typeof(System.Single))]
public class JLAnimationStateSetNormalizedSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.normalizedSpeed = Value.GetResult<System.Single>(context);
    }
}
