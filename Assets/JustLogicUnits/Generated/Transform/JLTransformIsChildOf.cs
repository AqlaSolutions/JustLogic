using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Is Child Of")]
[UnitFriendlyName("Is Child Of")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLTransformIsChildOf : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Parent;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.IsChildOf(Parent.GetResult<UnityEngine.Transform>(context));
    }
}
