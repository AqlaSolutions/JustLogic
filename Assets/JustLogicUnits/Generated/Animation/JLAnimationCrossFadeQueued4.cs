using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade Queued Advanced")]
[UnitFriendlyName("Animation.Cross Fade Queued Advanced")]
[UnitUsage(typeof(AnimationState), HideExpressionInActionsList = true)]
public class JLAnimationCrossFadeQueued4 : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression FadeLength;

    [Parameter(ExpressionType = typeof(QueueMode))]
    public JLExpression Queue;

    [Parameter(ExpressionType = typeof(PlayMode))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.CrossFadeQueued(Animation.GetResult<System.String>(context), FadeLength.GetResult<System.Single>(context), Queue.GetResult<QueueMode>(context), Mode.GetResult<PlayMode>(context));
    }
}
