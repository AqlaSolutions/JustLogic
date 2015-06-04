using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Current Animator State Info")]
[UnitFriendlyName("Animator.Get Current Animator State Info")]
[UnitUsage(typeof(AnimatorStateInfo), HideExpressionInActionsList = true)]
public class JLAnimatorGetCurrentAnimatorStateInfo : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetCurrentAnimatorStateInfo(LayerIndex.GetResult<System.Int32>(context));
    }
}
