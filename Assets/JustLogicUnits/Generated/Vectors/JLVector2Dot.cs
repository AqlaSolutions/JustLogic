using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Dot (Vector2)")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2Dot : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.Dot(Lhs.GetResult<UnityEngine.Vector2>(context), Rhs.GetResult<UnityEngine.Vector2>(context));
    }
}
