using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Radius (Character Controller)")]
[UnitFriendlyName("Get Radius")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.radius;
    }
}
