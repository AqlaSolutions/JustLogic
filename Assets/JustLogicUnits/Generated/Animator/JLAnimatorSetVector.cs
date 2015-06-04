using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Vector")]
[UnitFriendlyName("Animator.Set Vector")]
public class JLAnimatorSetVector : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetVector(Name.GetResult<System.String>(context), Value.GetResult<Vector3>(context));
        return null;
    }
}
