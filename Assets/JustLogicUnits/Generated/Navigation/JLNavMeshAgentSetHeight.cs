using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Height")]
[UnitFriendlyName("NavMeshAgent.Set Height")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.height = Value.GetResult<System.Single>(context);
    }
}
