using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Root Position")]
[UnitFriendlyName("Animator.Set Root Position")]
[UnitUsage(typeof(Vector3))]
public class JLAnimatorSetRootPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.rootPosition = Value.GetResult<Vector3>(context);
    }
}
