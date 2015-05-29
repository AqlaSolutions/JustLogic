using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Root Rotation")]
[UnitFriendlyName("Animator.Set Root Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion))]
public class JLAnimatorSetRootRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.rootRotation = Value.GetResult<UnityEngine.Quaternion>(context);
    }
}
