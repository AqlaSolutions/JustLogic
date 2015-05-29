using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Root Position")]
[UnitFriendlyName("Animator.Set Root Position")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLAnimatorSetRootPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.rootPosition = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
