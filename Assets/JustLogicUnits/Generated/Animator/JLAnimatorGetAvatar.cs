using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Avatar")]
[UnitFriendlyName("Animator.Get Avatar")]
[UnitUsage(typeof(UnityEngine.Avatar), HideExpressionInActionsList = true)]
public class JLAnimatorGetAvatar : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.avatar;
    }
}
