using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Velocity")]
[UnitFriendlyName("JLNavMeshObstacle.Get Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.velocity;
    }
}
