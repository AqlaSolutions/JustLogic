using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Background Color")]
[UnitFriendlyName("Camera.Set Background Color")]
[UnitUsage(typeof(UnityEngine.Color))]
public class JLCameraSetBackgroundColor : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.backgroundColor = Value.GetResult<UnityEngine.Color>(context);
    }
}
