using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Delta Rotation")]
[UnitFriendlyName("Animator.Get Delta Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLAnimatorGetDeltaRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.deltaRotation;
    }
}
