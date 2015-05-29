using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Calculate Path")]
[UnitFriendlyName("NavMeshAgent.Calculate Path")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshAgentCalculatePath : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression TargetPosition;

    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshPath))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.CalculatePath(TargetPosition.GetResult<UnityEngine.Vector3>(context), Path.GetResult<UnityEngine.NavMeshPath>(context));
    }
}
