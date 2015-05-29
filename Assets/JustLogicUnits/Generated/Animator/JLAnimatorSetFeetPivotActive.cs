using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Feet Pivot Active")]
[UnitFriendlyName("Animator.Set Feet Pivot Active")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetFeetPivotActive : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.feetPivotActive = Value.GetResult<System.Single>(context);
    }
}
