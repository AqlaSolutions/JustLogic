using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Move (Character Controller)")]
[UnitFriendlyName("Move")]
[UnitUsage(typeof(UnityEngine.CollisionFlags), HideExpressionInActionsList = true)]
public class JLCharacterControllerMove : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Motion;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.Move(Motion.GetResult<UnityEngine.Vector3>(context));
    }
}
