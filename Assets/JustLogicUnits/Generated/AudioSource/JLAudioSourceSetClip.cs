using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Clip")]
[UnitFriendlyName("Audio.Set Clip")]
[UnitUsage(typeof(AudioClip))]
public class JLAudioSourceSetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AudioClip))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.clip = Value.GetResult<AudioClip>(context);
    }
}
