using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Velocity")]
[UnitFriendlyName("JLNavMeshObstacle.Get Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.velocity;
    }
}
