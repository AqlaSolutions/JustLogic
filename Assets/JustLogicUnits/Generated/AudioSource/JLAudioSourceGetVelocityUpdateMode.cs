using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Velocity Update Mode")]
[UnitFriendlyName("Audio.Get Velocity Update Mode")]
[UnitUsage(typeof(AudioVelocityUpdateMode), HideExpressionInActionsList = true)]
public class JLAudioSourceGetVelocityUpdateMode : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.velocityUpdateMode;
    }
}
