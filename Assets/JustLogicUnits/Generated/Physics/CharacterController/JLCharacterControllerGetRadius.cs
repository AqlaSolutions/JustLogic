using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Radius (Character Controller)")]
[UnitFriendlyName("Get Radius")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLCharacterControllerGetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.radius;
    }
}
