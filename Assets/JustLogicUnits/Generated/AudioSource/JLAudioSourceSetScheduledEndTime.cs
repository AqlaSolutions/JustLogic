using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Set Scheduled End Time")]
[UnitFriendlyName("Audio.Set Scheduled End Time")]
public class JLAudioSourceSetScheduledEndTime : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Double))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        opValue.SetScheduledEndTime(Time.GetResult<System.Double>(context));
        return null;
    }
}
