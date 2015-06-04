using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Get Relative Torque")]
[UnitFriendlyName("ConstantForce.Get Relative Torque")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLConstantForceGetRelativeTorque : JLExpression
{
    [Parameter(ExpressionType = typeof(ConstantForce))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        ConstantForce opValue = OperandValue.GetResult<ConstantForce>(context);
        return opValue.relativeTorque;
    }
}
