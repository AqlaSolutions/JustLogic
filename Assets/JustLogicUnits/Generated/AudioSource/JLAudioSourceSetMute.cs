using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Mute")]
[UnitFriendlyName("Audio.Set Mute")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetMute : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.mute = Value.GetResult<System.Boolean>(context);
    }
}
