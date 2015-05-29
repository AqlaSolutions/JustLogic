using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Scheduled Start Time")]
[UnitFriendlyName("Audio.Set Scheduled Start Time")]
public class JLAudioSourceSetScheduledStartTime : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Double))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        opValue.SetScheduledStartTime(Time.GetResult<System.Double>(context));
        return null;
    }
}
