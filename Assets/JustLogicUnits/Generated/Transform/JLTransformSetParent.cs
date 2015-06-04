using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Parent")]
[UnitFriendlyName("Set Parent")]
[UnitUsage(typeof(Transform))]
public class JLTransformSetParent : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.parent = Value.GetResult<Transform>(context);
    }
}
