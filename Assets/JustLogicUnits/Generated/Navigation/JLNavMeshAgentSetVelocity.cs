using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Velocity")]
[UnitFriendlyName("NavMeshAgent.Set Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLNavMeshAgentSetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.velocity = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
