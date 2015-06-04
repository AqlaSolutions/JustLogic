using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Speed")]
[UnitFriendlyName("Animator.Get Speed")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimatorGetSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.speed;
    }
}
