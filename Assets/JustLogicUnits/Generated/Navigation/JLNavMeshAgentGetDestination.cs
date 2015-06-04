using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Destination")]
[UnitFriendlyName("NavMeshAgent.Get Destination")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetDestination : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.destination;
    }
}
