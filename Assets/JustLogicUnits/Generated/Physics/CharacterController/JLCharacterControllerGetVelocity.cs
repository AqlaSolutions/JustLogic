using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Velocity (Character Controller)")]
[UnitFriendlyName("Get Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.velocity;
    }
}
