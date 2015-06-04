using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Play On Awake")]
[UnitFriendlyName("Audio.Set Play On Awake")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetPlayOnAwake : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.playOnAwake = Value.GetResult<System.Boolean>(context);
    }
}
