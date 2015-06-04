using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Position")]
[UnitFriendlyName("JLNavMeshHit.Set Position")]
[UnitUsage(typeof(NavMeshHit))]
public class JLNavMeshHitSetPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        opValue.position = Value.GetResult<Vector3>(context);
        return opValue;
    }
}
