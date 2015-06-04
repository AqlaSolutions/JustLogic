using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Has Path")]
[UnitFriendlyName("NavMeshAgent.Get Has Path")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetHasPath : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.hasPath;
    }
}
