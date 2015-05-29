using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Next Off Mesh Link Data")]
[UnitFriendlyName("NavMeshAgent.Get Next Off Mesh Link Data")]
[UnitUsage(typeof(UnityEngine.OffMeshLinkData), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetNextOffMeshLinkData : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.nextOffMeshLinkData;
    }
}
