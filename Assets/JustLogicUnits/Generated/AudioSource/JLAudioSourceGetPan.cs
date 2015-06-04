using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Pan")]
[UnitFriendlyName("Audio.Get Pan")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAudioSourceGetPan : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.panStereo;
    }
}
