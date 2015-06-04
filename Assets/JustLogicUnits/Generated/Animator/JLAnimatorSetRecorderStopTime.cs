using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Recorder Stop Time")]
[UnitFriendlyName("Animator.Set Recorder Stop Time")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetRecorderStopTime : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.recorderStopTime = Value.GetResult<System.Single>(context);
    }
}
