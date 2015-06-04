using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Calculate Path")]
[UnitFriendlyName("NavMeshAgent.Calculate Path")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentCalculatePath : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression TargetPosition;

    [Parameter(ExpressionType = typeof(NavMeshPath))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.CalculatePath(TargetPosition.GetResult<Vector3>(context), Path.GetResult<NavMeshPath>(context));
    }
}
