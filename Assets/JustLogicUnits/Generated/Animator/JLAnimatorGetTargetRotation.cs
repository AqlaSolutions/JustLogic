using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Target Rotation")]
[UnitFriendlyName("Animator.Get Target Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetTargetRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.targetRotation;
    }
}
