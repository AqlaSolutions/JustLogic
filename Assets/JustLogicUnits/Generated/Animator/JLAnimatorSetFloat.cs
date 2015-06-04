using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Float")]
[UnitFriendlyName("Animator.Set Float")]
public class JLAnimatorSetFloat : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetFloat(Name.GetResult<System.String>(context), Value.GetResult<System.Single>(context));
        return null;
    }
}
