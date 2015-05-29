using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Layer Cull Spherical")]
[UnitFriendlyName("Camera.Set Layer Cull Spherical")]
[UnitUsage(typeof(System.Boolean))]
public class JLCameraSetLayerCullSpherical : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.layerCullSpherical = Value.GetResult<System.Boolean>(context);
    }
}
