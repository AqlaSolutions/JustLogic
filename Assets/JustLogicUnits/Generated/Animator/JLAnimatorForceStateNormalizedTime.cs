/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Force State Normalized Time")]
[UnitFriendlyName("Animator.Force State Normalized Time")]
public class JLAnimatorForceStateNormalizedTime : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NormalizedTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.ForceStateNormalizedTime(NormalizedTime.GetResult<System.Single>(context));
        return null;
    }
}
*/