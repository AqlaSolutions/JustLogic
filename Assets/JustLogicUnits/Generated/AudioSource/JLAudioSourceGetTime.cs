using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Time")]
[UnitFriendlyName("Audio.Get Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAudioSourceGetTime : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.time;
    }
}
