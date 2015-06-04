using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Mask")]
[UnitFriendlyName("JLNavMeshHit.Set Mask")]
[UnitUsage(typeof(NavMeshHit))]
public class JLNavMeshHitSetMask : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        opValue.mask = Value.GetResult<System.Int32>(context);
        return opValue;
    }
}
