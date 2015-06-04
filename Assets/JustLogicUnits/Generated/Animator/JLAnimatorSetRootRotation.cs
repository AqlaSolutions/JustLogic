using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Root Rotation")]
[UnitFriendlyName("Animator.Set Root Rotation")]
[UnitUsage(typeof(Quaternion))]
public class JLAnimatorSetRootRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.rootRotation = Value.GetResult<Quaternion>(context);
    }
}
