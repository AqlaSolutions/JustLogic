using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Auto Traverse Off Mesh Link")]
[UnitFriendlyName("NavMeshAgent.Get Auto Traverse Off Mesh Link")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetAutoTraverseOffMeshLink : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.autoTraverseOffMeshLink;
    }
}
