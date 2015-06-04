using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Velocity Update Mode")]
[UnitFriendlyName("Audio.Set Velocity Update Mode")]
[UnitUsage(typeof(AudioVelocityUpdateMode))]
public class JLAudioSourceSetVelocityUpdateMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AudioVelocityUpdateMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.velocityUpdateMode = Value.GetResult<AudioVelocityUpdateMode>(context);
    }
}
