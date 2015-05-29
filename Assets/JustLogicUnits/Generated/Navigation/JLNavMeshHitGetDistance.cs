using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Get Distance")]
[UnitFriendlyName("JLNavMeshHit.Get Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshHitGetDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        return opValue.distance;
    }
}
