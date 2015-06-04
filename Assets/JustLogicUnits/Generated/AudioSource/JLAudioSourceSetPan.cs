using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Pan")]
[UnitFriendlyName("Audio.Set Pan")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetPan : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.panStereo = Value.GetResult<System.Single>(context);
    }
}
