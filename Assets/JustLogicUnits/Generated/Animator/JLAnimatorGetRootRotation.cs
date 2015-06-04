using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Root Rotation")]
[UnitFriendlyName("Animator.Get Root Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetRootRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.rootRotation;
    }
}
