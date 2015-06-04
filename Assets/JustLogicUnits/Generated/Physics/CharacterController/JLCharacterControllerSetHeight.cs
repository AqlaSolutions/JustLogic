using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Height (Character Controller)")]
[UnitFriendlyName("Set Height")]
[UnitUsage(typeof(System.Single))]
public class JLCharacterControllerSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        CharacterController opValue = OperandValue.GetResult<CharacterController>(context);
        return opValue.height = Value.GetResult<System.Single>(context);
    }
}
