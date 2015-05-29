using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Stabilize Feet")]
[UnitFriendlyName("Animator.Set Stabilize Feet")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimatorSetStabilizeFeet : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.stabilizeFeet = Value.GetResult<System.Boolean>(context);
    }
}
