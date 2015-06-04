using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Height")]
[UnitFriendlyName("JLNavMeshObstacle.Set Height")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshObstacleSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshObstacle opValue = OperandValue.GetResult<NavMeshObstacle>(context);
        return opValue.height = Value.GetResult<System.Single>(context);
    }
}
