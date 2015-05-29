using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Parent")]
[UnitFriendlyName("Set Parent")]
[UnitUsage(typeof(UnityEngine.Transform))]
public class JLTransformSetParent : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.parent = Value.GetResult<UnityEngine.Transform>(context);
    }
}
