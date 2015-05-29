using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Velocity Update Mode")]
[UnitFriendlyName("Audio.Set Velocity Update Mode")]
[UnitUsage(typeof(UnityEngine.AudioVelocityUpdateMode))]
public class JLAudioSourceSetVelocityUpdateMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AudioVelocityUpdateMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.velocityUpdateMode = Value.GetResult<UnityEngine.AudioVelocityUpdateMode>(context);
    }
}
