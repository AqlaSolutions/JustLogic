using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Distance (Vector2)")]
[UnitFriendlyName("Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2Distance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.Distance(A.GetResult<UnityEngine.Vector2>(context), B.GetResult<UnityEngine.Vector2>(context));
    }
}
