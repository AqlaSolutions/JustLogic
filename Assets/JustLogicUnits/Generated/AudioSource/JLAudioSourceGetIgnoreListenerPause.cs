using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Ignore Listener Pause")]
[UnitFriendlyName("Audio.Get Ignore Listener Pause")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAudioSourceGetIgnoreListenerPause : JLExpression
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        return opValue.ignoreListenerPause;
    }
}
