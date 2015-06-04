using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Get Distance")]
[UnitFriendlyName("JLNavMeshHit.Get Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshHitGetDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        return opValue.distance;
    }
}
