using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Loop")]
[UnitFriendlyName("Audio.Set Loop")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetLoop : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.loop = Value.GetResult<System.Boolean>(context);
    }
}
