using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Equality (Vector3)")]
[UnitFriendlyName("Op Equality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLVector3OpEquality : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Vector3>(context) == Rhs.GetResult<Vector3>(context);
    }
}
