using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Clip")]
[UnitFriendlyName("Audio.Set Clip")]
[UnitUsage(typeof(UnityEngine.AudioClip))]
public class JLAudioSourceSetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AudioClip))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.clip = Value.GetResult<UnityEngine.AudioClip>(context);
    }
}
