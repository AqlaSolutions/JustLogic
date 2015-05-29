using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Camera To World Matrix")]
[UnitFriendlyName("Camera.Get Camera To World Matrix")]
[UnitUsage(typeof(UnityEngine.Matrix4x4), HideExpressionInActionsList = true)]
public class JLCameraGetCameraToWorldMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.cameraToWorldMatrix;
    }
}
