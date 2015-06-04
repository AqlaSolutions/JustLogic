using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Distance (Vector3)")]
[UnitFriendlyName("Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3Distance : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Distance(A.GetResult<Vector3>(context), B.GetResult<Vector3>(context));
    }
}
