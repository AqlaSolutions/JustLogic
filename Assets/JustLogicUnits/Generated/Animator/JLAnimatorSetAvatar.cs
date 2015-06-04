using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Avatar")]
[UnitFriendlyName("Animator.Set Avatar")]
[UnitUsage(typeof(Avatar))]
public class JLAnimatorSetAvatar : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Avatar))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.avatar = Value.GetResult<Avatar>(context);
    }
}
