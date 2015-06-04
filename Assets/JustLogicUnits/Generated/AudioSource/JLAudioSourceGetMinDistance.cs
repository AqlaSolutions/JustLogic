using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Min Distance")]
[UnitFriendlyName("Audio.Get Min Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAudioSourceGetMinDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.minDistance;
    }
}
