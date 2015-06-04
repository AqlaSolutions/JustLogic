using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Set/Set Y (Vector2)")]
[UnitFriendlyName("Set Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2SetY : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector2 opValue = Target.GetResult<Vector2>(context);
        return opValue.y = Value.GetResult<System.Single>(context);
    }
}
