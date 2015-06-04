using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Bool")]
[UnitFriendlyName("Animator.Set Bool")]
public class JLAnimatorSetBool : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetBool(Name.GetResult<System.String>(context), Value.GetResult<System.Boolean>(context));
        return null;
    }
}
