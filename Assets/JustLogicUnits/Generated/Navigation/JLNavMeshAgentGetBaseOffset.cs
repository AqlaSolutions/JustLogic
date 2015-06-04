using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Base Offset")]
[UnitFriendlyName("NavMeshAgent.Get Base Offset")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetBaseOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        return opValue.baseOffset;
    }
}
