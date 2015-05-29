using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Walkable Mask")]
[UnitFriendlyName("NavMeshAgent.Set Walkable Mask")]
[UnitUsage(typeof(System.Int32))]
public class JLNavMeshAgentSetWalkableMask : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.walkableMask = Value.GetResult<System.Int32>(context);
    }
}
