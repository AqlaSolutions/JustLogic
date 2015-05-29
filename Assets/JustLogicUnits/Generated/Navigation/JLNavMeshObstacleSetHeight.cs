using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Height")]
[UnitFriendlyName("JLNavMeshObstacle.Set Height")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshObstacleSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.height = Value.GetResult<System.Single>(context);
    }
}
