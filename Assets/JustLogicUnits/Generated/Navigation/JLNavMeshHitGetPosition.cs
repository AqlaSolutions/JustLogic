using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Get Position")]
[UnitFriendlyName("JLNavMeshHit.Get Position")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLNavMeshHitGetPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        return opValue.position;
    }
}
