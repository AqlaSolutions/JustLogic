using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Magnitude (Vector4)")]
[UnitFriendlyName("Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4Magnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.Magnitude(A.GetResult<Vector4>(context));
    }
}
