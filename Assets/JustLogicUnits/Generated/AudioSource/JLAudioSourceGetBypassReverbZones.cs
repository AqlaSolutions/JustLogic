using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Bypass Reverb Zones")]
[UnitFriendlyName("Audio.Get Bypass Reverb Zones")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAudioSourceGetBypassReverbZones : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.bypassReverbZones;
    }
}
