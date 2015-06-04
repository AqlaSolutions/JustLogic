using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Layer Cull Spherical")]
[UnitFriendlyName("Camera.Get Layer Cull Spherical")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCameraGetLayerCullSpherical : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.layerCullSpherical;
    }
}
