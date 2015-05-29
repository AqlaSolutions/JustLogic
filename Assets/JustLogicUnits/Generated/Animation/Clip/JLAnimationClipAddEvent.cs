using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Add Event")]
[UnitFriendlyName("AnimationClip.Add Event")]
public class JLAnimationClipAddEvent : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimationEvent))]
    public JLExpression Evt;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        opValue.AddEvent(Evt.GetResult<UnityEngine.AnimationEvent>(context));
        return null;
    }
}
