using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Equality (Vector2)")]
[UnitFriendlyName("Op Equality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLVector2OpEquality : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<UnityEngine.Vector2>(context) == Rhs.GetResult<UnityEngine.Vector2>(context);
    }
}
