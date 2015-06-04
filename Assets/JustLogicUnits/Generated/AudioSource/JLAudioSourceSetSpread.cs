using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Spread")]
[UnitFriendlyName("Audio.Set Spread")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetSpread : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.spread = Value.GetResult<System.Single>(context);
    }
}
