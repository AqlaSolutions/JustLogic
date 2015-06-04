using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Angular Speed")]
[UnitFriendlyName("NavMeshAgent.Set Angular Speed")]
[UnitUsage(typeof(System.Single))]
public class JLNavMeshAgentSetAngularSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.angularSpeed = Value.GetResult<System.Single>(context);
    }
}
