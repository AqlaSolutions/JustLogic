using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Velocity")]
[UnitFriendlyName("NavMeshAgent.Set Velocity")]
[UnitUsage(typeof(Vector3))]
public class JLNavMeshAgentSetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.velocity = Value.GetResult<Vector3>(context);
    }
}
