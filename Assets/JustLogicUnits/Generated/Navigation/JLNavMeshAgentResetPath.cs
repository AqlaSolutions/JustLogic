using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Reset Path")]
[UnitFriendlyName("NavMeshAgent.Reset Path")]
public class JLNavMeshAgentResetPath : JLAction
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        opValue.ResetPath();
        return null;
    }
}
