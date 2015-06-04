using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Closest Point On Bounds (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Closest Point On Bounds")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyClosestPointOnBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.ClosestPointOnBounds(Position.GetResult<Vector3>(context));
    }
}
