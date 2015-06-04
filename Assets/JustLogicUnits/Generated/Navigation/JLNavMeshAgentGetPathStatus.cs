using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Path Status")]
[UnitFriendlyName("NavMeshAgent.Get Path Status")]
[UnitUsage(typeof(NavMeshPathStatus), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetPathStatus : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.pathStatus;
    }
}
