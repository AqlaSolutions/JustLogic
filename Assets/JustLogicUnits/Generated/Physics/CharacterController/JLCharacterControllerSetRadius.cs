using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Radius (Character Controller)")]
[UnitFriendlyName("Set Radius")]
[UnitUsage(typeof(System.Single))]
public class JLCharacterControllerSetRadius : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.radius = Value.GetResult<System.Single>(context);
    }
}
