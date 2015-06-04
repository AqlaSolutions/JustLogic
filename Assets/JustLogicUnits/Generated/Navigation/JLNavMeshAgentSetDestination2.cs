using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Destination")]
[UnitFriendlyName("NavMeshAgent.Set Destination")]
[UnitUsage(typeof(Vector3))]
public class JLNavMeshAgentSetDestination2 : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.destination = Value.GetResult<Vector3>(context);
    }
}
