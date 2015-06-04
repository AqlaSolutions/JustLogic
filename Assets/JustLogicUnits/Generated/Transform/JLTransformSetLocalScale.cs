using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Local Scale")]
[UnitFriendlyName("Set Local Scale")]
[UnitUsage(typeof(Vector3))]
public class JLTransformSetLocalScale : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localScale = Value.GetResult<Vector3>(context);
    }
}
