using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Play Advanced")]
[UnitFriendlyName("Animation.Play Advanced")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimationPlay4 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter]
    public float Speed = 1f;

    [Parameter(ExpressionType = typeof(UnityEngine.PlayMode))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        var clip = Animation.GetResult<System.String>(context);
        AnimationState state = opValue[clip];
        state.speed = Speed;
        state.time = Speed < -float.Epsilon ? state.length : 0f;
        return opValue.Play(clip, Mode.GetResult<UnityEngine.PlayMode>(context));
    }
}
