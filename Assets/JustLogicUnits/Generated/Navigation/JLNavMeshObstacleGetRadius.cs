using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Radius")]
[UnitFriendlyName("JLNavMeshObstacle.Get Radius")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.radius;
    }
}
