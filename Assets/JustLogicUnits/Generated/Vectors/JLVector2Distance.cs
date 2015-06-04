using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Distance (Vector2)")]
[UnitFriendlyName("Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2Distance : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Distance(A.GetResult<Vector2>(context), B.GetResult<Vector2>(context));
    }
}
