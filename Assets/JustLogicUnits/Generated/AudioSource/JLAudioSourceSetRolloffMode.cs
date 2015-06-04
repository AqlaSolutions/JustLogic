using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Rolloff Mode")]
[UnitFriendlyName("Audio.Set Rolloff Mode")]
[UnitUsage(typeof(AudioRolloffMode))]
public class JLAudioSourceSetRolloffMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AudioRolloffMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.rolloffMode = Value.GetResult<AudioRolloffMode>(context);
    }
}
