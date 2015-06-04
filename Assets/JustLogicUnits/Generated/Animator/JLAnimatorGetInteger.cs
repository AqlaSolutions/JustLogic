using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Integer")]
[UnitFriendlyName("Animator.Get Integer")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAnimatorGetInteger : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetInteger(Name.GetResult<System.String>(context));
    }
}
