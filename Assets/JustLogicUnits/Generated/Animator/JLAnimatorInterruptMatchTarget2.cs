using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Interrupt Match Target")]
[UnitFriendlyName("Animator.Interrupt Match Target")]
public class JLAnimatorInterruptMatchTarget2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression CompleteMatch;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.InterruptMatchTarget(CompleteMatch.GetResult<System.Boolean>(context));
        return null;
    }
}
