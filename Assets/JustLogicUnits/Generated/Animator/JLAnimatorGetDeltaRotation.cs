using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Delta Rotation")]
[UnitFriendlyName("Animator.Get Delta Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetDeltaRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.deltaRotation;
    }
}
