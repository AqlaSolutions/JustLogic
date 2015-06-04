using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Body Rotation")]
[UnitFriendlyName("Animator.Set Body Rotation")]
[UnitUsage(typeof(Quaternion))]
public class JLAnimatorSetBodyRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.bodyRotation = Value.GetResult<Quaternion>(context);
    }
}
