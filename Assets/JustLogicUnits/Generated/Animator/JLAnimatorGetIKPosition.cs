using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get IKPosition")]
[UnitFriendlyName("Animator.Get IKPosition")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLAnimatorGetIKPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetIKPosition(Goal.GetResult<AvatarIKGoal>(context));
    }
}
