using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Set Clip")]
[UnitFriendlyName("Animation.Set Clip")]
[UnitUsage(typeof(UnityEngine.AnimationClip))]
public class JLAnimationSetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.clip = Value.GetResult<UnityEngine.AnimationClip>(context);
    }
}
