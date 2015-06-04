using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Clamp Magnitude (Vector2)")]
[UnitFriendlyName("Clamp Magnitude")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2ClampMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Vector;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxLength;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.ClampMagnitude(Vector.GetResult<Vector2>(context), MaxLength.GetResult<System.Single>(context));
    }
}
