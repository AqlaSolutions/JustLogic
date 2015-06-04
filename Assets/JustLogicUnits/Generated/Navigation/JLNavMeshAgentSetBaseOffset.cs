using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Base Offset")]
[UnitFriendlyName("NavMeshAgent.Set Base Offset")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetBaseOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.baseOffset = Value.GetResult<System.Single>(context);
    }
}
