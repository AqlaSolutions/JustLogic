using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Hit/Set Hit")]
[UnitFriendlyName("JLNavMeshHit.Set Hit")]
[UnitUsage(typeof(NavMeshHit))]
public class JLNavMeshHitSetHit : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshHit))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshHit opValue = OperandValue.GetResult<NavMeshHit>(context);
        opValue.hit = Value.GetResult<System.Boolean>(context);
        return opValue;
    }
}
