using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Gravity Weight")]
[UnitFriendlyName("Animator.Get Gravity Weight")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimatorGetGravityWeight : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.gravityWeight;
    }
}
