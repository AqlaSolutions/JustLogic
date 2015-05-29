using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Unary Negation (Vector3)")]
[UnitFriendlyName("Op Unary Negation")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3OpUnaryNegation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return -A.GetResult<UnityEngine.Vector3>(context);
    }
}
