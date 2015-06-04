using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Find")]
[UnitFriendlyName("Find")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLTransformFind : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.Find(Name.GetResult<System.String>(context));
    }
}
