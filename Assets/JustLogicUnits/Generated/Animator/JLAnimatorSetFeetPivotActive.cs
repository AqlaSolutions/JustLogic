using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Feet Pivot Active")]
[UnitFriendlyName("Animator.Set Feet Pivot Active")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetFeetPivotActive : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.feetPivotActive = Value.GetResult<System.Single>(context);
    }
}
