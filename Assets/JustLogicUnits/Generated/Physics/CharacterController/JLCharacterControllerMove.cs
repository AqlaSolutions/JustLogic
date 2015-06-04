using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Move (Character Controller)")]
[UnitFriendlyName("Move")]
[UnitUsage(typeof(CollisionFlags), HideExpressionInActionsList = true)]
public class JLCharacterControllerMove : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Motion;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.Move(Motion.GetResult<Vector3>(context));
    }
}
