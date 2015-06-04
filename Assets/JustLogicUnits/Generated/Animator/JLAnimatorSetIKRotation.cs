using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKRotation")]
[UnitFriendlyName("Animator.Set IKRotation")]
public class JLAnimatorSetIKRotation : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression GoalRotation;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetIKRotation(Goal.GetResult<AvatarIKGoal>(context), GoalRotation.GetResult<Quaternion>(context));
        return null;
    }
}
