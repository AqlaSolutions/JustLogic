using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Layer Name")]
[UnitFriendlyName("Animator.Get Layer Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAnimatorGetLayerName : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.GetLayerName(LayerIndex.GetResult<System.Int32>(context));
    }
}
