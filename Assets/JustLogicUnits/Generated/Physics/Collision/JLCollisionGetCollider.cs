using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Collider")]
[UnitFriendlyName("Collision.Get Collider")]
[UnitUsage(typeof(Collider), HideExpressionInActionsList = true)]
public class JLCollisionGetCollider : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.collider;
    }
}
