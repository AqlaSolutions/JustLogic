using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Speed")]
[UnitFriendlyName("Animator.Set Speed")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.speed = Value.GetResult<System.Single>(context);
    }
}
