using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Rotation")]
[UnitFriendlyName("Set Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion))]
public class JLTransformSetRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.rotation = Value.GetResult<UnityEngine.Quaternion>(context);
    }
}
