using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Angle (Vector2)")]
[UnitFriendlyName("Angle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2Angle : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression To;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.Angle(From.GetResult<Vector2>(context), To.GetResult<Vector2>(context));
    }
}
