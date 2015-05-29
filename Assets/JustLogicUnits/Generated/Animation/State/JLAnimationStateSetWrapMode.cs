using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Set Wrap Mode")]
[UnitFriendlyName("AnimationState.Set Wrap Mode")]
[UnitUsage(typeof(UnityEngine.WrapMode))]
public class JLAnimationStateSetWrapMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.WrapMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.wrapMode = Value.GetResult<UnityEngine.WrapMode>(context);
    }
}
