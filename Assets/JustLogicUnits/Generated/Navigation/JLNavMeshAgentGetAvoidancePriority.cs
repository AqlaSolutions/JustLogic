using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Avoidance Priority")]
[UnitFriendlyName("NavMeshAgent.Get Avoidance Priority")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetAvoidancePriority : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.avoidancePriority;
    }
}
