using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Add Mixing Transform")]
[UnitFriendlyName("AnimationState.Add Mixing Transform")]
public class JLAnimationStateAddMixingTransform2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Mix;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Recursive;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        opValue.AddMixingTransform(Mix.GetResult<UnityEngine.Transform>(context), Recursive.GetResult<System.Boolean>(context));
        return null;
    }
}
