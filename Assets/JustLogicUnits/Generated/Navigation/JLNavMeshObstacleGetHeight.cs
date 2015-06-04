using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Height")]
[UnitFriendlyName("JLNavMeshObstacle.Get Height")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.height;
    }
}
