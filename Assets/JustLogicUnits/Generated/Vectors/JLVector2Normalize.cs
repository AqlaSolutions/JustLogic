using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Normalize (Vector2)")]
[UnitFriendlyName("Normalize")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2Normalize : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector2 opValue = OperandValue.GetResult<Vector2>(context);
        opValue.Normalize();
        return opValue;
    }
}
