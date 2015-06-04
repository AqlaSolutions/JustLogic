using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Distance")]
[UnitFriendlyName("JLNavMeshHit.Set Distance")]
[UnitUsage(typeof(NavMeshHit))]
public class JLNavMeshHitSetDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        opValue.distance = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
