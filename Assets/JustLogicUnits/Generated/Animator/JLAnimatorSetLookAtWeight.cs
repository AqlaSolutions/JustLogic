using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Look At Weight")]
[UnitFriendlyName("Animator.Set Look At Weight")]
public class JLAnimatorSetLookAtWeight : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Weight;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetLookAtWeight(Weight.GetResult<System.Single>(context));
        return null;
    }
}
