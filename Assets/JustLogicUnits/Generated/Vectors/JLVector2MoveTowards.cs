using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector2)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.MoveTowards(Current.GetResult<UnityEngine.Vector2>(context), Target.GetResult<UnityEngine.Vector2>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
