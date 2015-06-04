using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Local Rotation")]
[UnitFriendlyName("Set Local Rotation")]
[UnitUsage(typeof(Quaternion))]
public class JLTransformSetLocalRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localRotation = Value.GetResult<Quaternion>(context);
    }
}
