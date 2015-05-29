using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Match Target")]
[UnitFriendlyName("Animator.Match Target")]
public class JLAnimatorMatchTarget : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression MatchPosition;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression MatchRotation;

    [Parameter(ExpressionType = typeof(UnityEngine.AvatarTarget))]
    public JLExpression TargetBodyPart;

    [Parameter(ExpressionType = typeof(UnityEngine.MatchTargetWeightMask))]
    public JLExpression WeightMask;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression StartNormalizedTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.MatchTarget(MatchPosition.GetResult<UnityEngine.Vector3>(context), MatchRotation.GetResult<UnityEngine.Quaternion>(context), TargetBodyPart.GetResult<UnityEngine.AvatarTarget>(context), WeightMask.GetResult<UnityEngine.MatchTargetWeightMask>(context), StartNormalizedTime.GetResult<System.Single>(context));
        return null;
    }
}
