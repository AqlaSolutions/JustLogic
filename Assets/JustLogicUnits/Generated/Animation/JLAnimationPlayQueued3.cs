using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play Queued Advanced")]
[UnitFriendlyName("Animation.Play Queued Advanced")]
[UnitUsage(typeof(AnimationState))]
public class JLAnimationPlayQueued3 : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(QueueMode))]
    public JLExpression Queue;

    [Parameter(ExpressionType = typeof(PlayMode))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.PlayQueued(Animation.GetResult<System.String>(context), Queue.GetResult<QueueMode>(context), Mode.GetResult<PlayMode>(context));
    }
}
