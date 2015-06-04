using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/New Nav Mesh Agent")]
[UnitFriendlyName("NavMeshAgent.New Nav Mesh Agent")]
[UnitUsage(typeof(NavMeshAgent), HideExpressionInActionsList = true)]
public class JLNavMeshAgentNewNavMeshAgent : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return new NavMeshAgent();
    }
}
