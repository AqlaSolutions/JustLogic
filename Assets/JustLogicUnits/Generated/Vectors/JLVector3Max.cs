using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Max (Vector3)")]
[UnitFriendlyName("Max")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Max : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Max(Lhs.GetResult<Vector3>(context), Rhs.GetResult<Vector3>(context));
    }
}
