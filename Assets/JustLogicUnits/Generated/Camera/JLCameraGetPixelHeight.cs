using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Pixel Height")]
[UnitFriendlyName("Camera.Get Pixel Height")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLCameraGetPixelHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.pixelHeight;
    }
}
