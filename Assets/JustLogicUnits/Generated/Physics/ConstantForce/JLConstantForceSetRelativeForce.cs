using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Set Relative Force")]
[UnitFriendlyName("ConstantForce.Set Relative Force")]
[UnitUsage(typeof(Vector3))]
public class JLConstantForceSetRelativeForce : JLExpression
{
    [Parameter(ExpressionType = typeof(ConstantForce))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        ConstantForce opValue = OperandValue.GetResult<ConstantForce>(context);
        return opValue.relativeForce = Value.GetResult<Vector3>(context);
    }
}
