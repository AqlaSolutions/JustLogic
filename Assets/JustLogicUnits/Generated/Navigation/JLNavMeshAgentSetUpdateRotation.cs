using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Update Rotation")]
[UnitFriendlyName("NavMeshAgent.Set Update Rotation")]
[UnitUsage(typeof(System.Boolean))]
public class JLNavMeshAgentSetUpdateRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.updateRotation = Value.GetResult<System.Boolean>(context);
    }
}
