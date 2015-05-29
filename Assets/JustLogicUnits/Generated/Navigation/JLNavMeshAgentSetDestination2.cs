using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Destination")]
[UnitFriendlyName("NavMeshAgent.Set Destination")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLNavMeshAgentSetDestination2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.destination = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
