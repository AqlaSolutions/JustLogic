using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Collider")]
[UnitFriendlyName("Collision.Get Collider")]
[UnitUsage(typeof(UnityEngine.Collider), HideExpressionInActionsList = true)]
public class JLCollisionGetCollider : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collision opValue = OperandValue.GetResult<UnityEngine.Collision>(context);
        return opValue.collider;
    }
}
