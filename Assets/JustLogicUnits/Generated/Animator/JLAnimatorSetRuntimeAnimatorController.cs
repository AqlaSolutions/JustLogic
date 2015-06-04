using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Runtime Animator Controller")]
[UnitFriendlyName("Animator.Set Runtime Animator Controller")]
[UnitUsage(typeof(RuntimeAnimatorController))]
public class JLAnimatorSetRuntimeAnimatorController : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(RuntimeAnimatorController))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.runtimeAnimatorController = Value.GetResult<RuntimeAnimatorController>(context);
    }
}
