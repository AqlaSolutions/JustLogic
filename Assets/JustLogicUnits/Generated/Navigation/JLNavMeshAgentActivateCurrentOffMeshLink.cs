using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Agent/Activate Current Off Mesh Link")]
[UnitFriendlyName("NavMeshAgent.Activate Current Off Mesh Link")]
public class JLNavMeshAgentActivateCurrentOffMeshLink : JLAction
{
    [Parameter(ExpressionType = typeof(NavMeshAgent))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Activated;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        NavMeshAgent opValue = OperandValue.GetResult<NavMeshAgent>(context);
        opValue.ActivateCurrentOffMeshLink(Activated.GetResult<System.Boolean>(context));
        return null;
    }
}
