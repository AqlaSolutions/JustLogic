using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Feet Pivot Active")]
[UnitFriendlyName("Animator.Get Feet Pivot Active")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimatorGetFeetPivotActive : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.feetPivotActive;
    }
}
