using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Dot (Vector3)")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3Dot : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Dot(Lhs.GetResult<Vector3>(context), Rhs.GetResult<Vector3>(context));
    }
}
