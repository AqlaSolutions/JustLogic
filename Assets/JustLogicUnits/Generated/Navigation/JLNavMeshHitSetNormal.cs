using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Normal")]
[UnitFriendlyName("JLNavMeshHit.Set Normal")]
[UnitUsage(typeof(NavMeshHit))]
public class JLNavMeshHitSetNormal : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        opValue.normal = Value.GetResult<Vector3>(context);
        return opValue;
    }
}
