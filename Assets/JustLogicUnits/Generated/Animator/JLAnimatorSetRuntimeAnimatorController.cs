using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Runtime Animator Controller")]
[UnitFriendlyName("Animator.Set Runtime Animator Controller")]
[UnitUsage(typeof(UnityEngine.RuntimeAnimatorController))]
public class JLAnimatorSetRuntimeAnimatorController : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.RuntimeAnimatorController))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.runtimeAnimatorController = Value.GetResult<UnityEngine.RuntimeAnimatorController>(context);
    }
}
