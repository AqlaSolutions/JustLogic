using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Look At Position")]
[UnitFriendlyName("Animator.Set Look At Position")]
public class JLAnimatorSetLookAtPosition : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression LookAtPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetLookAtPosition(LookAtPosition.GetResult<UnityEngine.Vector3>(context));
        return null;
    }
}
