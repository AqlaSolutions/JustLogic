using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Doppler Level")]
[UnitFriendlyName("Audio.Set Doppler Level")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetDopplerLevel : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.dopplerLevel = Value.GetResult<System.Single>(context);
    }
}
