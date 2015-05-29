using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play Queued")]
[UnitFriendlyName("Animation.Play Queued")]
[UnitUsage(typeof(UnityEngine.AnimationState))]
public class JLAnimationPlayQueued : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.PlayQueued(Animation.GetResult<System.String>(context));
    }
}
