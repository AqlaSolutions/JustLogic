using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Get Mask")]
[UnitFriendlyName("JLNavMeshHit.Get Mask")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLNavMeshHitGetMask : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        return opValue.mask;
    }
}
