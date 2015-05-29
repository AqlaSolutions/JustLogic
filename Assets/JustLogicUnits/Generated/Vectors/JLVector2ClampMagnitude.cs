using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Clamp Magnitude (Vector2)")]
[UnitFriendlyName("Clamp Magnitude")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2ClampMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Vector;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxLength;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.ClampMagnitude(Vector.GetResult<UnityEngine.Vector2>(context), MaxLength.GetResult<System.Single>(context));
    }
}
