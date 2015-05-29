using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Closest Point On Bounds (Character Controller)")]
[UnitFriendlyName("Closest Point On Bounds")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLCharacterControllerClosestPointOnBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.ClosestPointOnBounds(Position.GetResult<UnityEngine.Vector3>(context));
    }
}
