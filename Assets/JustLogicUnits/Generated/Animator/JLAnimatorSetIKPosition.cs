using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKPosition")]
[UnitFriendlyName("Animator.Set IKPosition")]
public class JLAnimatorSetIKPosition : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression GoalPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetIKPosition(Goal.GetResult<UnityEngine.AvatarIKGoal>(context), GoalPosition.GetResult<UnityEngine.Vector3>(context));
        return null;
    }
}
