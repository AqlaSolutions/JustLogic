using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Local Euler Angles")]
[UnitFriendlyName("Set Local Euler Angles")]
[UnitUsage(typeof(Vector3))]
public class JLTransformSetLocalEulerAngles : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localEulerAngles = Value.GetResult<Vector3>(context);
    }
}
