using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Desired Velocity")]
[UnitFriendlyName("NavMeshAgent.Get Desired Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetDesiredVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.desiredVelocity;
    }
}
