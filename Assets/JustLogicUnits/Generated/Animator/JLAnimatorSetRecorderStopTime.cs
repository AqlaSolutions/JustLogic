using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Recorder Stop Time")]
[UnitFriendlyName("Animator.Set Recorder Stop Time")]
[UnitUsage(typeof(System.Single))]
public class JLAnimatorSetRecorderStopTime : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.recorderStopTime = Value.GetResult<System.Single>(context);
    }
}
