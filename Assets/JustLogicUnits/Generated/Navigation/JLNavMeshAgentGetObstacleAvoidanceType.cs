using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Obstacle Avoidance Type")]
[UnitFriendlyName("NavMeshAgent.Get Obstacle Avoidance Type")]
[UnitUsage(typeof(UnityEngine.ObstacleAvoidanceType), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetObstacleAvoidanceType : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.obstacleAvoidanceType;
    }
}
