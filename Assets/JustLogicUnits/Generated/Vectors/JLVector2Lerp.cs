using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector2)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Lerp(From.GetResult<Vector2>(context), To.GetResult<Vector2>(context), T.GetResult<System.Single>(context));
    }
}
