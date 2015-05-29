using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Mask")]
[UnitFriendlyName("JLNavMeshHit.Set Mask")]
[UnitUsage(typeof(UnityEngine.NavMeshHit))]
public class JLNavMeshHitSetMask : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshHit opValue = OperandValue.GetResult<UnityEngine.NavMeshHit>(context);
        opValue.mask = Value.GetResult<System.Int32>(context);
        return opValue;
    }
}
