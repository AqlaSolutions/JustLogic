using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Delta Position")]
[UnitFriendlyName("Animator.Get Delta Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLAnimatorGetDeltaPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.deltaPosition;
    }
}
