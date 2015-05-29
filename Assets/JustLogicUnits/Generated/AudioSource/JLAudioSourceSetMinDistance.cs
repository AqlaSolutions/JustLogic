using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Min Distance")]
[UnitFriendlyName("Audio.Set Min Distance")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetMinDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.minDistance = Value.GetResult<System.Single>(context);
    }
}
