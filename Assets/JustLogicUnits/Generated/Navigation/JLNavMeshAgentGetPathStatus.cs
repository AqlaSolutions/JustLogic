using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Path Status")]
[UnitFriendlyName("NavMeshAgent.Get Path Status")]
[UnitUsage(typeof(UnityEngine.NavMeshPathStatus), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetPathStatus : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.pathStatus;
    }
}
