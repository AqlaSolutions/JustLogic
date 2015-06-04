using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Normalized (Vector2)")]
[UnitFriendlyName("Get Normalized")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2GetNormalized : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector2 opValue = OperandValue.GetResult<Vector2>(context);
        return opValue.normalized;
    }
}
