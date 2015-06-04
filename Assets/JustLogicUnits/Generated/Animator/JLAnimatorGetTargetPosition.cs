using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Target Position")]
[UnitFriendlyName("Animator.Get Target Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLAnimatorGetTargetPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.targetPosition;
    }
}
