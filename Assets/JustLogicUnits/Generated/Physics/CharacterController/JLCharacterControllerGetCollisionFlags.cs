using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Collision Flags (Character Controller)")]
[UnitFriendlyName("Get Collision Flags")]
[UnitUsage(typeof(UnityEngine.CollisionFlags), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetCollisionFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.collisionFlags;
    }
}
