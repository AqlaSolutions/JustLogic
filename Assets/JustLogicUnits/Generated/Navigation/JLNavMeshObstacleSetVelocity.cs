using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Set Velocity")]
[UnitFriendlyName("JLNavMeshObstacle.Set Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLNavMeshObstacleSetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.velocity = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
