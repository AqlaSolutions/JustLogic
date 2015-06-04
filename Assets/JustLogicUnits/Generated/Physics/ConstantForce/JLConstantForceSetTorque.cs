using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Set Torque")]
[UnitFriendlyName("ConstantForce.Set Torque")]
[UnitUsage(typeof(Vector3))]
public class JLConstantForceSetTorque : JLExpression
{
    [Parameter(ExpressionType = typeof(ConstantForce))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        ConstantForce opValue = OperandValue.GetResult<ConstantForce>(context);
        return opValue.torque = Value.GetResult<Vector3>(context);
    }
}
