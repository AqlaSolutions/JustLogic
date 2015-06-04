using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Magnitude (Vector3)")]
[UnitFriendlyName("Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3Magnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Magnitude(A.GetResult<Vector3>(context));
    }
}
