using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Normal")]
[UnitFriendlyName("JLNavMeshHit.Set Normal")]
[UnitUsage(typeof(UnityEngine.NavMeshHit))]
public class JLNavMeshHitSetNormal : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        opValue.normal = Value.GetResult<UnityEngine.Vector3>(context);
        return opValue;
    }
}
