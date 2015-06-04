using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKRotation Weight")]
[UnitFriendlyName("Animator.Set IKRotation Weight")]
public class JLAnimatorSetIKRotationWeight : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetIKRotationWeight(Goal.GetResult<AvatarIKGoal>(context), Value.GetResult<System.Single>(context));
        return null;
    }
}
