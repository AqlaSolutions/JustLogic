using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Background Color")]
[UnitFriendlyName("Camera.Set Background Color")]
[UnitUsage(typeof(Color))]
public class JLCameraSetBackgroundColor : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.backgroundColor = Value.GetResult<Color>(context);
    }
}
