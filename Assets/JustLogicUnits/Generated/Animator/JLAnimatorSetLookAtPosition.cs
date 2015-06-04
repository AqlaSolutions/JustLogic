using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Look At Position")]
[UnitFriendlyName("Animator.Set Look At Position")]
public class JLAnimatorSetLookAtPosition : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression LookAtPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetLookAtPosition(LookAtPosition.GetResult<Vector3>(context));
        return null;
    }
}
