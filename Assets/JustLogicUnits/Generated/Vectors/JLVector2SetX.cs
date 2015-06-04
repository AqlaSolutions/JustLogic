using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Set/Set X (Vector2)")]
[UnitFriendlyName("Set X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2SetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector2 opValue = Target.GetResult<Vector2>(context);
        return opValue.x = Value.GetResult<System.Single>(context);
    }
}
