using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade Queued")]
[UnitFriendlyName("Animation.Cross Fade Queued")]
[UnitUsage(typeof(UnityEngine.AnimationState), HideExpressionInActionsList = true)]
public class JLAnimationCrossFadeQueued : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.CrossFadeQueued(Animation.GetResult<System.String>(context));
    }
}
