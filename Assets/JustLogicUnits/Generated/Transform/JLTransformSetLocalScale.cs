using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Set Local Scale")]
[UnitFriendlyName("Set Local Scale")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLTransformSetLocalScale : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.localScale = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
