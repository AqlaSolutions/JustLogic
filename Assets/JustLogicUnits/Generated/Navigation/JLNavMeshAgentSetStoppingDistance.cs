using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Stopping Distance")]
[UnitFriendlyName("NavMeshAgent.Set Stopping Distance")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetStoppingDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.stoppingDistance = Value.GetResult<System.Single>(context);
    }
}
