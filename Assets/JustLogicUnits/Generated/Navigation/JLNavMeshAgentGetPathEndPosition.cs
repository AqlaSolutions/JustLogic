using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Path End Position")]
[UnitFriendlyName("NavMeshAgent.Get Path End Position")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetPathEndPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.pathEndPosition;
    }
}
