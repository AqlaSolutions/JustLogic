using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Avatar")]
[UnitFriendlyName("Animator.Set Avatar")]
[UnitUsage(typeof(UnityEngine.Avatar))]
public class JLAnimatorSetAvatar : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Avatar))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.avatar = Value.GetResult<UnityEngine.Avatar>(context);
    }
}
