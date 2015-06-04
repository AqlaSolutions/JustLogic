using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Is Path Stale")]
[UnitFriendlyName("NavMeshAgent.Get Is Path Stale")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetIsPathStale : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.isPathStale;
    }
}
