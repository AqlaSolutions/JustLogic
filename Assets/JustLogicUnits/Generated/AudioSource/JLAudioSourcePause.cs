using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Pause")]
[UnitFriendlyName("Audio.Pause")]
public class JLAudioSourcePause : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.Pause();
        return null;
    }
}
