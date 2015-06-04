using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Obstacle Avoidance Type")]
[UnitFriendlyName("NavMeshAgent.Set Obstacle Avoidance Type")]
[UnitUsage(typeof(ObstacleAvoidanceType))]
public class JLNavMeshAgentSetObstacleAvoidanceType : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(ObstacleAvoidanceType))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.obstacleAvoidanceType = Value.GetResult<ObstacleAvoidanceType>(context);
    }
}
