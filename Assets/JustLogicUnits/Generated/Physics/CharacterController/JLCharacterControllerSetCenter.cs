using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Center (Character Controller)")]
[UnitFriendlyName("Set Center")]
[UnitUsage(typeof(Vector3))]
public class JLCharacterControllerSetCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.center = Value.GetResult<Vector3>(context);
    }
}
