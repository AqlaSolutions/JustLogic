using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Remove Mixing Transform")]
[UnitFriendlyName("AnimationState.Remove Mixing Transform")]
public class JLAnimationStateRemoveMixingTransform : JLAction
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Mix;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        opValue.RemoveMixingTransform(Mix.GetResult<Transform>(context));
        return null;
    }
}
