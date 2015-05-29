using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Body Rotation")]
[UnitFriendlyName("Animator.Get Body Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetBodyRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.bodyRotation;
    }
}
