using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Subtraction (Vector3)")]
[UnitFriendlyName("Op Subtraction")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3OpSubtraction : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Vector3>(context) - B.GetResult<Vector3>(context);
    }
}
