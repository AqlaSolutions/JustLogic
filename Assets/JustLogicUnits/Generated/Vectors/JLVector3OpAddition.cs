using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Addition (Vector3)")]
[UnitFriendlyName("Op Addition")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3OpAddition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Vector3>(context) + B.GetResult<UnityEngine.Vector3>(context);
    }
}
