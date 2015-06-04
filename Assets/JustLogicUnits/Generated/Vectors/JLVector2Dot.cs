using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Dot (Vector2)")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2Dot : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Dot(Lhs.GetResult<Vector2>(context), Rhs.GetResult<Vector2>(context));
    }
}
