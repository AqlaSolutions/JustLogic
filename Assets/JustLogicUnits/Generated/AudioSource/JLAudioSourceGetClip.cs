using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Clip")]
[UnitFriendlyName("Audio.Get Clip")]
[UnitUsage(typeof(AudioClip), HideExpressionInActionsList = true)]
public class JLAudioSourceGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.clip;
    }
}
