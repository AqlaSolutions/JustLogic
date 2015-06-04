using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Bypass Reverb Zones")]
[UnitFriendlyName("Audio.Set Bypass Reverb Zones")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetBypassReverbZones : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.bypassReverbZones = Value.GetResult<System.Boolean>(context);
    }
}
