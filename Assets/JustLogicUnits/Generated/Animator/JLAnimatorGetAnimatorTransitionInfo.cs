using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Animator Transition Info")]
[UnitFriendlyName("Animator.Get Animator Transition Info")]
[UnitUsage(typeof(AnimatorTransitionInfo), HideExpressionInActionsList = true)]
public class JLAnimatorGetAnimatorTransitionInfo : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetAnimatorTransitionInfo(LayerIndex.GetResult<System.Int32>(context));
    }
}
