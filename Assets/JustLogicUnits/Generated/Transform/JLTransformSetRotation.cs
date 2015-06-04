using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Rotation")]
[UnitFriendlyName("Set Rotation")]
[UnitUsage(typeof(Quaternion))]
public class JLTransformSetRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.rotation = Value.GetResult<Quaternion>(context);
    }
}
