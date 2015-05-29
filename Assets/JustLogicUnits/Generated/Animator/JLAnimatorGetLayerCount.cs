using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Layer Count")]
[UnitFriendlyName("Animator.Get Layer Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAnimatorGetLayerCount : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.layerCount;
    }
}
