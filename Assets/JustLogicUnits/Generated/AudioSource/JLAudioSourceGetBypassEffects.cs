using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Bypass Effects")]
[UnitFriendlyName("Audio.Get Bypass Effects")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAudioSourceGetBypassEffects : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.bypassEffects;
    }
}
