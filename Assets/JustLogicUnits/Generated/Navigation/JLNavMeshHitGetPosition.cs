using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Get Position")]
[UnitFriendlyName("JLNavMeshHit.Get Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshHitGetPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        return opValue.position;
    }
}
