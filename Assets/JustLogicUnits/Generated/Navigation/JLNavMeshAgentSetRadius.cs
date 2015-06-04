using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Radius")]
[UnitFriendlyName("NavMeshAgent.Set Radius")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.radius = Value.GetResult<System.Single>(context);
    }
}
