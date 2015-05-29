using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Remove Mixing Transform")]
[UnitFriendlyName("AnimationState.Remove Mixing Transform")]
public class JLAnimationStateRemoveMixingTransform : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Mix;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        opValue.RemoveMixingTransform(Mix.GetResult<UnityEngine.Transform>(context));
        return null;
    }
}
