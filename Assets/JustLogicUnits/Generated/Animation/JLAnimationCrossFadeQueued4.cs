using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade Queued Advanced")]
[UnitFriendlyName("Animation.Cross Fade Queued Advanced")]
[UnitUsage(typeof(UnityEngine.AnimationState), HideExpressionInActionsList = true)]
public class JLAnimationCrossFadeQueued4 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression FadeLength;

    [Parameter(ExpressionType = typeof(UnityEngine.QueueMode))]
    public JLExpression Queue;

    [Parameter(ExpressionType = typeof(UnityEngine.PlayMode))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.CrossFadeQueued(Animation.GetResult<System.String>(context), FadeLength.GetResult<System.Single>(context), Queue.GetResult<UnityEngine.QueueMode>(context), Mode.GetResult<UnityEngine.PlayMode>(context));
    }
}
