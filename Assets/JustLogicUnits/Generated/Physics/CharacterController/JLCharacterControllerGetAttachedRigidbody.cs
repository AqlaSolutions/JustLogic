using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Attached Rigidbody (Character Controller)")]
[UnitFriendlyName("Get Attached Rigidbody")]
[UnitUsage(typeof(Rigidbody), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetAttachedRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.attachedRigidbody;
    }
}
