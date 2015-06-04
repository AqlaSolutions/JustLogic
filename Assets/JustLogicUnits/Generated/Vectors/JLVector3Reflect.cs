using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Reflect (Vector3)")]
[UnitFriendlyName("Reflect")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Reflect : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression InDirection;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression InNormal;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Reflect(InDirection.GetResult<Vector3>(context), InNormal.GetResult<Vector3>(context));
    }
}
