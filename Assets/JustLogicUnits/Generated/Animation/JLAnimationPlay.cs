using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play")]
[UnitFriendlyName("Animation.Play")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimationPlay : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter]
    public float Speed = 1f;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        var clip = Animation.GetResult<string>(context);
        AnimationState state = opValue[clip];
        state.speed = Speed;
        state.time = Speed < -float.Epsilon ? state.length : 0f;
        return opValue.Play(clip);
    }
}
