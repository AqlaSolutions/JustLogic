using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Name")]
[UnitFriendlyName("AnimationState.Set Name")]
[UnitUsage(typeof(System.String))]
public class JLAnimationStateSetName : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.name = Value.GetResult<System.String>(context);
    }
}
