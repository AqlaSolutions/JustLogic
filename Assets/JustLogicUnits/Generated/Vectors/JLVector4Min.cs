using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Min (Vector4)")]
[UnitFriendlyName("Min")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4Min : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.Min(Lhs.GetResult<Vector4>(context), Rhs.GetResult<Vector4>(context));
    }
}
