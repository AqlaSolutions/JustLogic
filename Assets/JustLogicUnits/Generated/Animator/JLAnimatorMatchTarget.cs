using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Match Target")]
[UnitFriendlyName("Animator.Match Target")]
public class JLAnimatorMatchTarget : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression MatchPosition;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression MatchRotation;

    [Parameter(ExpressionType = typeof(AvatarTarget))]
    public JLExpression TargetBodyPart;

    [Parameter(ExpressionType = typeof(MatchTargetWeightMask))]
    public JLExpression WeightMask;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression StartNormalizedTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.MatchTarget(MatchPosition.GetResult<Vector3>(context), MatchRotation.GetResult<Quaternion>(context), TargetBodyPart.GetResult<AvatarTarget>(context), WeightMask.GetResult<MatchTargetWeightMask>(context), StartNormalizedTime.GetResult<System.Single>(context));
        return null;
    }
}
