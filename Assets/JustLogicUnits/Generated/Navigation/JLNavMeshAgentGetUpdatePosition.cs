using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Update Position")]
[UnitFriendlyName("NavMeshAgent.Get Update Position")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetUpdatePosition : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.updatePosition;
    }
}
