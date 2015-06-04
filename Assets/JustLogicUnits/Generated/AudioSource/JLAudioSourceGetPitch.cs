using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Pitch")]
[UnitFriendlyName("Audio.Get Pitch")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAudioSourceGetPitch : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.pitch;
    }
}
