using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Position")]
[UnitFriendlyName("JLNavMeshHit.Set Position")]
[UnitUsage(typeof(UnityEngine.NavMeshHit))]
public class JLNavMeshHitSetPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        opValue.position = Value.GetResult<UnityEngine.Vector3>(context);
        return opValue;
    }
}
