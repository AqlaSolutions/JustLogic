using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Add Mixing Transform")]
[UnitFriendlyName("AnimationState.Add Mixing Transform")]
public class JLAnimationStateAddMixingTransform2 : JLAction
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Mix;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Recursive;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        opValue.AddMixingTransform(Mix.GetResult<Transform>(context), Recursive.GetResult<System.Boolean>(context));
        return null;
    }
}
