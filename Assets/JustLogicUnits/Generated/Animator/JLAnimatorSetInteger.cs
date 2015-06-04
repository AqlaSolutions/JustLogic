using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Integer")]
[UnitFriendlyName("Animator.Set Integer")]
public class JLAnimatorSetInteger : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetInteger(Name.GetResult<System.String>(context), Value.GetResult<System.Int32>(context));
        return null;
    }
}
