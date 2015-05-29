using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Target Rotation")]
[UnitFriendlyName("Animator.Get Target Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetTargetRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.targetRotation;
    }
}
