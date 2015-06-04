using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Unary Negation (Vector2)")]
[UnitFriendlyName("Op Unary Negation")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2OpUnaryNegation : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return -A.GetResult<Vector2>(context);
    }
}
