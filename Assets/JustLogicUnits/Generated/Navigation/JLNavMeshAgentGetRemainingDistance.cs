using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Remaining Distance")]
[UnitFriendlyName("NavMeshAgent.Get Remaining Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetRemainingDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.remainingDistance;
    }
}
