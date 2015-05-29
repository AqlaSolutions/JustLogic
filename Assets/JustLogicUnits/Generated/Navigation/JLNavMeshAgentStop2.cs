using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Stop")]
[UnitFriendlyName("NavMeshAgent.Stop")]
public class JLNavMeshAgentStop2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression StopUpdates;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.NavMeshAgent opValue = OperandValue.GetResult<UnityEngine.NavMeshAgent>(context);
        opValue.Stop(StopUpdates.GetResult<System.Boolean>(context));
        return null;
    }
}
