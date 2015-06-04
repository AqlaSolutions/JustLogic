using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Inequality (Vector2)")]
[UnitFriendlyName("Op Inequality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLVector2OpInequality : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Vector2>(context) != Rhs.GetResult<Vector2>(context);
    }
}
