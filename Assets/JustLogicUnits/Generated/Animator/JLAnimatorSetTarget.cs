using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Target")]
[UnitFriendlyName("Animator.Set Target")]
public class JLAnimatorSetTarget : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AvatarTarget))]
    public JLExpression TargetIndex;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TargetNormalizedTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetTarget(TargetIndex.GetResult<UnityEngine.AvatarTarget>(context), TargetNormalizedTime.GetResult<System.Single>(context));
        return null;
    }
}
