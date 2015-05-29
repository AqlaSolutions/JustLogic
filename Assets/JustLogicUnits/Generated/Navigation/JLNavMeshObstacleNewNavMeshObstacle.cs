using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/New Nav Mesh Obstacle")]
[UnitFriendlyName("JLNavMeshObstacle.New Nav Mesh Obstacle")]
[UnitUsage(typeof(UnityEngine.NavMeshObstacle), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleNewNavMeshObstacle : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.NavMeshObstacle();
    }
}
