using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Multiply (Vector2)")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2OpMultiply : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression D;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Vector2>(context) * D.GetResult<System.Single>(context);
    }
}
