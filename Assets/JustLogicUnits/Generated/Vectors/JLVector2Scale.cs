using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Scale (Vector2)")]
[UnitFriendlyName("Scale")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2Scale : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Scale;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector2 opValue = OperandValue.GetResult<Vector2>(context);
        opValue.Scale(Scale.GetResult<Vector2>(context));
        return opValue;
    }
}
