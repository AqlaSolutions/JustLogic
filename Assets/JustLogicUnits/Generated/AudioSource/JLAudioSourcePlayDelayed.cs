using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Play Delayed")]
[UnitFriendlyName("Audio.Play Delayed")]
public class JLAudioSourcePlayDelayed : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Delay;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.PlayDelayed(Delay.GetResult<System.Single>(context));
        return null;
    }
}
