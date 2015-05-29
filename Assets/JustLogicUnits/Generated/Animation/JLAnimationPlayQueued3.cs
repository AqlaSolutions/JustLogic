using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play Queued Advanced")]
[UnitFriendlyName("Animation.Play Queued Advanced")]
[UnitUsage(typeof(UnityEngine.AnimationState))]
public class JLAnimationPlayQueued3 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(UnityEngine.QueueMode))]
    public JLExpression Queue;

    [Parameter(ExpressionType = typeof(UnityEngine.PlayMode))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.PlayQueued(Animation.GetResult<System.String>(context), Queue.GetResult<UnityEngine.QueueMode>(context), Mode.GetResult<UnityEngine.PlayMode>(context));
    }
}
