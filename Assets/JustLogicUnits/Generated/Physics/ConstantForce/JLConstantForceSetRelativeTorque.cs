using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Set Relative Torque")]
[UnitFriendlyName("ConstantForce.Set Relative Torque")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLConstantForceSetRelativeTorque : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.ConstantForce))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.ConstantForce opValue = OperandValue.GetResult<UnityEngine.ConstantForce>(context);
        return opValue.relativeTorque = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
