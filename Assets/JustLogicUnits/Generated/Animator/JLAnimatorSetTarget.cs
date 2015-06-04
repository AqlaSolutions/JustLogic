using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Target")]
[UnitFriendlyName("Animator.Set Target")]
public class JLAnimatorSetTarget : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarTarget))]
    public JLExpression TargetIndex;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TargetNormalizedTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetTarget(TargetIndex.GetResult<AvatarTarget>(context), TargetNormalizedTime.GetResult<System.Single>(context));
        return null;
    }
}
