using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Radius")]
[UnitFriendlyName("JLNavMeshObstacle.Set Radius")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshObstacleSetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.radius = Value.GetResult<System.Single>(context);
    }
}
