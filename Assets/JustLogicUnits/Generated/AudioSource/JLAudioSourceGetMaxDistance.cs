using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Max Distance")]
[UnitFriendlyName("Audio.Get Max Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAudioSourceGetMaxDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.maxDistance;
    }
}
