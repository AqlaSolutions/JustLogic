using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Start Recording")]
[UnitFriendlyName("Animator.Start Recording")]
public class JLAnimatorStartRecording : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression FrameCount;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.StartRecording(FrameCount.GetResult<System.Int32>(context));
        return null;
    }
}
