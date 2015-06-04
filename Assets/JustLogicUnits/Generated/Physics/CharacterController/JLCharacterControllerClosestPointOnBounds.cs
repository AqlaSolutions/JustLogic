using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Closest Point On Bounds (Character Controller)")]
[UnitFriendlyName("Closest Point On Bounds")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCharacterControllerClosestPointOnBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.ClosestPointOnBounds(Position.GetResult<Vector3>(context));
    }
}
