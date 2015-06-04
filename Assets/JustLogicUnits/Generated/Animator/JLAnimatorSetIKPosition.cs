using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKPosition")]
[UnitFriendlyName("Animator.Set IKPosition")]
public class JLAnimatorSetIKPosition : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression GoalPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetIKPosition(Goal.GetResult<AvatarIKGoal>(context), GoalPosition.GetResult<Vector3>(context));
        return null;
    }
}
