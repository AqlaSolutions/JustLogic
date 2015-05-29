using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Current Off Mesh Link Data")]
[UnitFriendlyName("NavMeshAgent.Get Current Off Mesh Link Data")]
[UnitUsage(typeof(UnityEngine.OffMeshLinkData), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetCurrentOffMeshLinkData : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.currentOffMeshLinkData;
    }
}
