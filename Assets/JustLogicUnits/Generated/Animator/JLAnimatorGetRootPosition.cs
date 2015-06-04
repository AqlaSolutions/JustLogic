using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Root Position")]
[UnitFriendlyName("Animator.Get Root Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLAnimatorGetRootPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.rootPosition;
    }
}
