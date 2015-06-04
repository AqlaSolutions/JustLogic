using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Camera To World Matrix")]
[UnitFriendlyName("Camera.Get Camera To World Matrix")]
[UnitUsage(typeof(Matrix4x4), HideExpressionInActionsList = true)]
public class JLCameraGetCameraToWorldMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.cameraToWorldMatrix;
    }
}
