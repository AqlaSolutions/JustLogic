using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Min (Vector2)")]
[UnitFriendlyName("Min")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2Min : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.Min(Lhs.GetResult<UnityEngine.Vector2>(context), Rhs.GetResult<UnityEngine.Vector2>(context));
    }
}
