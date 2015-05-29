using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Center (Character Controller)")]
[UnitFriendlyName("Set Center")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLCharacterControllerSetCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.CharacterController))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.CharacterController opValue = OperandValue.GetResult<UnityEngine.CharacterController>(context);
        return opValue.center = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
