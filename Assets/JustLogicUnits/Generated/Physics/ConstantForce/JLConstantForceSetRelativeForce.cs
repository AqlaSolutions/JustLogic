using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Constant Force/Set Relative Force")]
[UnitFriendlyName("ConstantForce.Set Relative Force")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLConstantForceSetRelativeForce : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.ConstantForce))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.ConstantForce opValue = OperandValue.GetResult<UnityEngine.ConstantForce>(context);
        return opValue.relativeForce = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
