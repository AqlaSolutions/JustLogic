using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Local Position")]
[UnitFriendlyName("Set Local Position")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLTransformSetLocalPosition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.localPosition = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
