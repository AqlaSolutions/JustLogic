using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Wrap Mode")]
[UnitFriendlyName("AnimationState.Get Wrap Mode")]
[UnitUsage(typeof(UnityEngine.WrapMode), HideExpressionInActionsList = true)]
public class JLAnimationStateGetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.wrapMode;
    }
}
