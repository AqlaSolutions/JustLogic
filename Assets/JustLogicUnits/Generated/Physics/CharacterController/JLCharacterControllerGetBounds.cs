using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Bounds (Character Controller)")]
[UnitFriendlyName("Get Bounds")]
[UnitUsage(typeof(Bounds), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.bounds;
    }
}
