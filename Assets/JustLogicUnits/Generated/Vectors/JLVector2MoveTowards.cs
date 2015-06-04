using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector2)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.MoveTowards(Current.GetResult<Vector2>(context), Target.GetResult<Vector2>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
