using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Bypass Effects")]
[UnitFriendlyName("Audio.Set Bypass Effects")]
[UnitUsage(typeof(System.Boolean))]
public class JLAudioSourceSetBypassEffects : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.bypassEffects = Value.GetResult<System.Boolean>(context);
    }
}
