using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Inequality (Vector4)")]
[UnitFriendlyName("Op Inequality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLVector4OpInequality : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Vector4>(context) != Rhs.GetResult<Vector4>(context);
    }
}
