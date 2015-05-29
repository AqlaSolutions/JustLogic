using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Obstacle Avoidance Type")]
[UnitFriendlyName("NavMeshAgent.Set Obstacle Avoidance Type")]
[UnitUsage(typeof(UnityEngine.ObstacleAvoidanceType))]
public class JLNavMeshAgentSetObstacleAvoidanceType : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.ObstacleAvoidanceType))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.obstacleAvoidanceType = Value.GetResult<UnityEngine.ObstacleAvoidanceType>(context);
    }
}
