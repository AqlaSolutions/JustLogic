using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Body Position")]
[UnitFriendlyName("Animator.Set Body Position")]
[UnitUsage(typeof(Vector3))]
public class JLAnimatorSetBodyPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.bodyPosition = Value.GetResult<Vector3>(context);
    }
}
