using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Closest Point On Bounds (Collider)")]
[UnitFriendlyName("Collider.Closest Point On Bounds")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLColliderClosestPointOnBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(Collider))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collider opValue = OperandValue.GetResult<Collider>(context);
        return opValue.ClosestPointOnBounds(Position.GetResult<Vector3>(context));
    }
}
