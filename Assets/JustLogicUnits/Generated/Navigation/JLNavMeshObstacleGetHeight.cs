using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Obstacle/Get Height")]
[UnitFriendlyName("JLNavMeshObstacle.Get Height")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshObstacleGetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshObstacle))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshObstacle opValue = OperandValue.GetResult<UnityEngine.NavMeshObstacle>(context);
        return opValue.height;
    }
}
