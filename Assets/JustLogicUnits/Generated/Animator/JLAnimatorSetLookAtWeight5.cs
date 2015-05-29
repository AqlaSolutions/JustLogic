using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Look At Weight Advanced")]
[UnitFriendlyName("Animator.Set Look At Weight")]
public class JLAnimatorSetLookAtWeight5 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Weight;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression BodyWeight;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression HeadWeight;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression EyesWeight;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression ClampWeight;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetLookAtWeight(Weight.GetResult<System.Single>(context), BodyWeight.GetResult<System.Single>(context), HeadWeight.GetResult<System.Single>(context), EyesWeight.GetResult<System.Single>(context), ClampWeight.GetResult<System.Single>(context));
        return null;
    }
}
