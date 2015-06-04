using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Complete Off Mesh Link")]
[UnitFriendlyName("NavMeshAgent.Complete Off Mesh Link")]
public class JLNavMeshAgentCompleteOffMeshLink : JLAction
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        opValue.CompleteOffMeshLink();
        return null;
    }
}
