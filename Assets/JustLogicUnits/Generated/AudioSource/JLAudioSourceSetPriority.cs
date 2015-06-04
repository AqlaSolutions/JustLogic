using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Priority")]
[UnitFriendlyName("Audio.Set Priority")]
[UnitUsage(typeof(System.Int32))]
public class JLAudioSourceSetPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.priority = Value.GetResult<System.Int32>(context);
    }
}
