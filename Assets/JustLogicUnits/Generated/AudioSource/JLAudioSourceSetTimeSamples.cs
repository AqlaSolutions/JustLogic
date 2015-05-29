using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Time Samples")]
[UnitFriendlyName("Audio.Set Time Samples")]
[UnitUsage(typeof(System.Int32))]
public class JLAudioSourceSetTimeSamples : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.timeSamples = Value.GetResult<System.Int32>(context);
    }
}
