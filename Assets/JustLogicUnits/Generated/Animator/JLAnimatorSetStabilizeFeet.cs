using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Stabilize Feet")]
[UnitFriendlyName("Animator.Set Stabilize Feet")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimatorSetStabilizeFeet : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.stabilizeFeet = Value.GetResult<System.Boolean>(context);
    }
}
