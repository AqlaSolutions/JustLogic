using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Euler Angles")]
[UnitFriendlyName("Set Euler Angles")]
[UnitUsage(typeof(Vector3))]
public class JLTransformSetEulerAngles : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.eulerAngles = Value.GetResult<Vector3>(context);
    }
}
