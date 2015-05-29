using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Closest Point On Bounds (Collider)")]
[UnitFriendlyName("Collider.Closest Point On Bounds")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLColliderClosestPointOnBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collider))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collider opValue = OperandValue.GetResult<UnityEngine.Collider>(context);
        return opValue.ClosestPointOnBounds(Position.GetResult<UnityEngine.Vector3>(context));
    }
}
