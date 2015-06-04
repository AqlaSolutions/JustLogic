using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Is On Off Mesh Link")]
[UnitFriendlyName("NavMeshAgent.Get Is On Off Mesh Link")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetIsOnOffMeshLink : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.isOnOffMeshLink;
    }
}
