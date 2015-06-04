using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Interrupt Match Target")]
[UnitFriendlyName("Animator.Interrupt Match Target")]
public class JLAnimatorInterruptMatchTarget2 : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression CompleteMatch;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.InterruptMatchTarget(CompleteMatch.GetResult<System.Boolean>(context));
        return null;
    }
}
