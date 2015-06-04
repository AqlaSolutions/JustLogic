using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Addition (Vector2)")]
[UnitFriendlyName("Op Addition")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2OpAddition : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Vector2>(context) + B.GetResult<Vector2>(context);
    }
}
