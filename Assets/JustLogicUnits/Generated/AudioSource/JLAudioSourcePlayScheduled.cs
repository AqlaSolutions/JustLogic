using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Play Scheduled")]
[UnitFriendlyName("Audio.Play Scheduled")]
public class JLAudioSourcePlayScheduled : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Double))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.PlayScheduled(Time.GetResult<System.Double>(context));
        return null;
    }
}
