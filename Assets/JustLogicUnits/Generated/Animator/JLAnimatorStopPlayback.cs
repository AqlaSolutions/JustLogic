using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Stop Playback")]
[UnitFriendlyName("Animator.Stop Playback")]
public class JLAnimatorStopPlayback : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.StopPlayback();
        return null;
    }
}
