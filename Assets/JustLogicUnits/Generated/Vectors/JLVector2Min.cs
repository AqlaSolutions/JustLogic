using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Min (Vector2)")]
[UnitFriendlyName("Min")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2Min : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Min(Lhs.GetResult<Vector2>(context), Rhs.GetResult<Vector2>(context));
    }
}
