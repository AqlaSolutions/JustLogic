using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Playback Time")]
[UnitFriendlyName("Animator.Set Playback Time")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetPlaybackTime : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.playbackTime = Value.GetResult<System.Single>(context);
    }
}
