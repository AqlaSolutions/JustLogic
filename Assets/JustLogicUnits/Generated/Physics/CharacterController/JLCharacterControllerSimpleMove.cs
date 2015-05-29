using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Simple Move (Character Controller)")]
[UnitFriendlyName("Simple Move")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCharacterControllerSimpleMove : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Speed;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.SimpleMove(Speed.GetResult<UnityEngine.Vector3>(context));
    }
}
