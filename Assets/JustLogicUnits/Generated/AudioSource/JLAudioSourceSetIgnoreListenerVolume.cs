using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Ignore Listener Volume")]
[UnitFriendlyName("Audio.Set Ignore Listener Volume")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetIgnoreListenerVolume : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.ignoreListenerVolume = Value.GetResult<System.Boolean>(context);
    }
}
