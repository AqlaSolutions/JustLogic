using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Forward")]
[UnitFriendlyName("Set Forward")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLTransformSetForward : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.forward = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
