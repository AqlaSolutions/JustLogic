using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Rolloff Mode")]
[UnitFriendlyName("Audio.Get Rolloff Mode")]
[UnitUsage(typeof(UnityEngine.AudioRolloffMode), HideExpressionInActionsList = true)]
public class JLAudioSourceGetRolloffMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.rolloffMode;
    }
}
