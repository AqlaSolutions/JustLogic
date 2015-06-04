using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Velocity (Character Controller)")]
[UnitFriendlyName("Get Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.velocity;
    }
}
