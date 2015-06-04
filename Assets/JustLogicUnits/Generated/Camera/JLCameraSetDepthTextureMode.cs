using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Depth Texture Mode")]
[UnitFriendlyName("Camera.Set Depth Texture Mode")]
[UnitUsage(typeof(DepthTextureMode))]
public class JLCameraSetDepthTextureMode : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(DepthTextureMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.depthTextureMode = Value.GetResult<DepthTextureMode>(context);
    }
}
