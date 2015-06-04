using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Obstacle Avoidance Type")]
[UnitFriendlyName("NavMeshAgent.Get Obstacle Avoidance Type")]
[UnitUsage(typeof(ObstacleAvoidanceType), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetObstacleAvoidanceType : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.obstacleAvoidanceType;
    }
}
