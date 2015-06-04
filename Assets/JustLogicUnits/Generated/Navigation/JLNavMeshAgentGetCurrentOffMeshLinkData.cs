using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Current Off Mesh Link Data")]
[UnitFriendlyName("NavMeshAgent.Get Current Off Mesh Link Data")]
[UnitUsage(typeof(OffMeshLinkData), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetCurrentOffMeshLinkData : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.currentOffMeshLinkData;
    }
}
