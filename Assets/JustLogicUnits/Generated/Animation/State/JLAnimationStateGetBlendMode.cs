using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Blend Mode")]
[UnitFriendlyName("AnimationState.Get Blend Mode")]
[UnitUsage(typeof(UnityEngine.AnimationBlendMode), HideExpressionInActionsList = true)]
public class JLAnimationStateGetBlendMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.blendMode;
    }
}
