using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Velocity Update Mode")]
[UnitFriendlyName("Audio.Get Velocity Update Mode")]
[UnitUsage(typeof(UnityEngine.AudioVelocityUpdateMode), HideExpressionInActionsList = true)]
public class JLAudioSourceGetVelocityUpdateMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.velocityUpdateMode;
    }
}
