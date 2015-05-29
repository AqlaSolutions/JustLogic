using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKRotation")]
[UnitFriendlyName("Animator.Set IKRotation")]
public class JLAnimatorSetIKRotation : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression GoalRotation;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetIKRotation(Goal.GetResult<UnityEngine.AvatarIKGoal>(context), GoalRotation.GetResult<UnityEngine.Quaternion>(context));
        return null;
    }
}
