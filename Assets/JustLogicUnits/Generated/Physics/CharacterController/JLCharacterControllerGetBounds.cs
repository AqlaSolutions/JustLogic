using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Bounds (Character Controller)")]
[UnitFriendlyName("Get Bounds")]
[UnitUsage(typeof(UnityEngine.Bounds), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.bounds;
    }
}
