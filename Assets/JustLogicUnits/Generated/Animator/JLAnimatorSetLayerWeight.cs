using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Layer Weight")]
[UnitFriendlyName("Animator.Set Layer Weight")]
public class JLAnimatorSetLayerWeight : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LayerIndex;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Weight;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetLayerWeight(LayerIndex.GetResult<System.Int32>(context), Weight.GetResult<System.Single>(context));
        return null;
    }
}
