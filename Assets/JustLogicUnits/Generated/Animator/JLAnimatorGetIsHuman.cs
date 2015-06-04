using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Is Human")]
[UnitFriendlyName("Animator.Get Is Human")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimatorGetIsHuman : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.isHuman;
    }
}
