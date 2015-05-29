using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Distance")]
[UnitFriendlyName("JLNavMeshHit.Set Distance")]
[UnitUsage(typeof(UnityEngine.NavMeshHit))]
public class JLNavMeshHitSetDistance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        opValue.distance = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
