using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Max (Vector2)")]
[UnitFriendlyName("Max")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2Max : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Max(Lhs.GetResult<Vector2>(context), Rhs.GetResult<Vector2>(context));
    }
}
