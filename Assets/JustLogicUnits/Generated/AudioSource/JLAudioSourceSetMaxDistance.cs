using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Max Distance")]
[UnitFriendlyName("Audio.Set Max Distance")]
[UnitUsage(typeof(System.Single))]
public class JLAudioSourceSetMaxDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.maxDistance = Value.GetResult<System.Single>(context);
    }
}
