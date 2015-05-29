using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Get Path")]
[UnitFriendlyName("NavMeshAgent.Get Path")]
[UnitUsage(typeof(UnityEngine.NavMeshPath), HideExpressionInActionsList = true)]
public class JLNavMeshAgentGetPath : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        return opValue.path;
    }
}
