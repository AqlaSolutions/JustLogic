using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Depth Texture Mode")]
[UnitFriendlyName("Camera.Set Depth Texture Mode")]
[UnitUsage(typeof(UnityEngine.DepthTextureMode))]
public class JLCameraSetDepthTextureMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.DepthTextureMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.depthTextureMode = Value.GetResult<UnityEngine.DepthTextureMode>(context);
    }
}
