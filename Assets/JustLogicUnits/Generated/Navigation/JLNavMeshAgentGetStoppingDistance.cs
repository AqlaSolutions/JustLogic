using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Stopping Distance")]
[UnitFriendlyName("NavMeshAgent.Get Stopping Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetStoppingDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.stoppingDistance;
    }
}
