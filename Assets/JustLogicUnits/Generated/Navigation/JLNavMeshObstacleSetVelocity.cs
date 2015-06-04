using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Velocity")]
[UnitFriendlyName("JLNavMeshObstacle.Set Velocity")]
[UnitUsage(typeof(Vector3))]
public class JLNavMeshObstacleSetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.velocity = Value.GetResult<Vector3>(context);
    }
}
