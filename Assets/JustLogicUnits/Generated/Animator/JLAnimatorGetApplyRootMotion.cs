using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Apply Root Motion")]
[UnitFriendlyName("Animator.Get Apply Root Motion")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimatorGetApplyRootMotion : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.applyRootMotion;
    }
}
