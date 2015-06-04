using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Radius")]
[UnitFriendlyName("JLNavMeshObstacle.Get Radius")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.radius;
    }
}
