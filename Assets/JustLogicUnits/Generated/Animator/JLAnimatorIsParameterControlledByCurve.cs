using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Is Parameter Controlled By Curve")]
[UnitFriendlyName("Animator.Is Parameter Controlled By Curve")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimatorIsParameterControlledByCurve : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.IsParameterControlledByCurve(Name.GetResult<System.String>(context));
    }
}
