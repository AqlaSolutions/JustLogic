using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Next Position")]
[UnitFriendlyName("NavMeshAgent.Set Next Position")]
[UnitUsage(typeof(Vector3))]
public class JLNavMeshAgentSetNextPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.nextPosition = Value.GetResult<Vector3>(context);
    }
}
