using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Sqr Magnitude (Vector3)")]
[UnitFriendlyName("Sqr Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3SqrMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.SqrMagnitude(A.GetResult<Vector3>(context));
    }
}
