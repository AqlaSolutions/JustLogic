using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Clip")]
[UnitFriendlyName("Audio.Get Clip")]
[UnitUsage(typeof(UnityEngine.AudioClip), HideExpressionInActionsList = true)]
public class JLAudioSourceGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        return opValue.clip;
    }
}
