using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Is Grounded (Character Controller)")]
[UnitFriendlyName("Get Is Grounded")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetIsGrounded : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.isGrounded;
    }
}
