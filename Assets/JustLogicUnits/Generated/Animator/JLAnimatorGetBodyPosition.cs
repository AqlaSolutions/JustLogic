using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Body Position")]
[UnitFriendlyName("Animator.Get Body Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLAnimatorGetBodyPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.bodyPosition;
    }
}
