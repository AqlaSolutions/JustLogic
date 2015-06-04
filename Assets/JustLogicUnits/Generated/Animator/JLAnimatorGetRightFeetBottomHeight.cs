using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Right Feet Bottom Height")]
[UnitFriendlyName("Animator.Get Right Feet Bottom Height")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimatorGetRightFeetBottomHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.rightFeetBottomHeight;
    }
}
