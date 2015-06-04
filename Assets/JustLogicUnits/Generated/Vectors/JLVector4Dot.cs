using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Dot (Vector4)")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4Dot : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.Dot(A.GetResult<Vector4>(context), B.GetResult<Vector4>(context));
    }
}
