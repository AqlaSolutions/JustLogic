using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Next Animator State Info")]
[UnitFriendlyName("Animator.Get Next Animator State Info")]
[UnitUsage(typeof(AnimatorStateInfo), HideExpressionInActionsList = true)]
public class JLAnimatorGetNextAnimatorStateInfo : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetNextAnimatorStateInfo(LayerIndex.GetResult<System.Int32>(context));
    }
}
