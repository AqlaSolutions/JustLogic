using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Walkable Mask")]
[UnitFriendlyName("NavMeshAgent.Get Walkable Mask")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetWalkableMask : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.walkableMask;
    }
}
