using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Bypass Listener Effects")]
[UnitFriendlyName("Audio.Set Bypass Listener Effects")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetBypassListenerEffects : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.bypassListenerEffects = Value.GetResult<System.Boolean>(context);
    }
}
