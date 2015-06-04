using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Scheduled Start Time")]
[UnitFriendlyName("Audio.Set Scheduled Start Time")]
public class JLAudioSourceSetScheduledStartTime : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Double))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.SetScheduledStartTime(Time.GetResult<System.Double>(context));
        return null;
    }
}
