using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Rolloff Mode")]
[UnitFriendlyName("Audio.Set Rolloff Mode")]
[UnitUsage(typeof(UnityEngine.AudioRolloffMode))]
public class JLAudioSourceSetRolloffMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AudioRolloffMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.rolloffMode = Value.GetResult<UnityEngine.AudioRolloffMode>(context);
    }
}
