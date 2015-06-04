using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Avatar")]
[UnitFriendlyName("Animator.Get Avatar")]
[UnitUsage(typeof(Avatar), HideExpressionInActionsList = true)]
public class JLAnimatorGetAvatar : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.avatar;
    }
}
