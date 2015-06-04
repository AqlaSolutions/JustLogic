using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Radius")]
[UnitFriendlyName("JLNavMeshObstacle.Set Radius")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshObstacleSetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.radius = Value.GetResult<System.Single>(context);
    }
}
