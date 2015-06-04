using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Acceleration")]
[UnitFriendlyName("NavMeshAgent.Set Acceleration")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetAcceleration : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.acceleration = Value.GetResult<System.Single>(context);
    }
}
