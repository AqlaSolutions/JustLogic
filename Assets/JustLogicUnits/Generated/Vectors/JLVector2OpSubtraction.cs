using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Subtraction (Vector2)")]
[UnitFriendlyName("Op Subtraction")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2OpSubtraction : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Vector2>(context) - B.GetResult<UnityEngine.Vector2>(context);
    }
}
