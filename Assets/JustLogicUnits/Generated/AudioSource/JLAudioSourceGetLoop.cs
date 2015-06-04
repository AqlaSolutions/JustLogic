using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Loop")]
[UnitFriendlyName("Audio.Get Loop")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAudioSourceGetLoop : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.loop;
    }
}
