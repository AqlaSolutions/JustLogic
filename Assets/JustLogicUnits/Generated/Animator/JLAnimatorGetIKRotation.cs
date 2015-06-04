using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get IKRotation")]
[UnitFriendlyName("Animator.Get IKRotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetIKRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetIKRotation(Goal.GetResult<AvatarIKGoal>(context));
    }
}
