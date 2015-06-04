using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Collision Flags (Character Controller)")]
[UnitFriendlyName("Get Collision Flags")]
[UnitUsage(typeof(CollisionFlags), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetCollisionFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.collisionFlags;
    }
}
