using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play Queued")]
[UnitFriendlyName("Animation.Play Queued")]
[UnitUsage(typeof(AnimationState))]
public class JLAnimationPlayQueued : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.PlayQueued(Animation.GetResult<System.String>(context));
    }
}
