using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Set Path")]
[UnitFriendlyName("NavMeshAgent.Set Path")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentSetPath : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(NavMeshPath))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.SetPath(Path.GetResult<NavMeshPath>(context));
    }
}
