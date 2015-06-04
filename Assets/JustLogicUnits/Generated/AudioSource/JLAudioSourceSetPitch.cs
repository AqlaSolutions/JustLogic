using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Pitch")]
[UnitFriendlyName("Audio.Set Pitch")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetPitch : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.pitch = Value.GetResult<System.Single>(context);
    }
}
