using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Attached Rigidbody (Character Controller)")]
[UnitFriendlyName("Get Attached Rigidbody")]
[UnitUsage(typeof(UnityEngine.Rigidbody), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetAttachedRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.attachedRigidbody;
    }
}
