using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Speed")]
[UnitFriendlyName("NavMeshAgent.Set Speed")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.speed = Value.GetResult<System.Single>(context);
    }
}
