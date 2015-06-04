using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Simple Move (Character Controller)")]
[UnitFriendlyName("Simple Move")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCharacterControllerSimpleMove : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Speed;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.SimpleMove(Speed.GetResult<Vector3>(context));
    }
}
