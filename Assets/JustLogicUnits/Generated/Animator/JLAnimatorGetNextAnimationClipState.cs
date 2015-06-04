using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Next Animation Clip State")]
[UnitFriendlyName("Animator.Get Next Animation Clip State")]
[UnitUsage(typeof(AnimatorClipInfo[]), HideExpressionInActionsList = true)]
public class JLAnimatorGetNextAnimationClipState : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetNextAnimatorClipInfo(LayerIndex.GetResult<System.Int32>(context));
    }
}
