using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Pan Level")]
[UnitFriendlyName("Audio.Set Pan Level")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetPanLevel : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.spatialBlend = Value.GetResult<System.Single>(context);
    }
}
