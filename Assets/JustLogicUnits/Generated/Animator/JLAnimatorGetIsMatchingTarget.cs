using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Is Matching Target")]
[UnitFriendlyName("Animator.Get Is Matching Target")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimatorGetIsMatchingTarget : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.isMatchingTarget;
    }
}
