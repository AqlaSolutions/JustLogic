using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Set Torque")]
[UnitFriendlyName("ConstantForce.Set Torque")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLConstantForceSetTorque : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.ConstantForce))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.ConstantForce opValue = OperandValue.GetResult<UnityEngine.ConstantForce>(context);
        return opValue.torque = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
