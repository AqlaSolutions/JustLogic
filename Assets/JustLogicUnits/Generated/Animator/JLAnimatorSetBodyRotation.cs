using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Body Rotation")]
[UnitFriendlyName("Animator.Set Body Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion))]
public class JLAnimatorSetBodyRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.bodyRotation = Value.GetResult<UnityEngine.Quaternion>(context);
    }
}
