using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Auto Repath")]
[UnitFriendlyName("NavMeshAgent.Set Auto Repath")]
[UnitUsage(typeof(System.Boolean))]
public class JLNavMeshAgentSetAutoRepath : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.autoRepath = Value.GetResult<System.Boolean>(context);
    }
}
