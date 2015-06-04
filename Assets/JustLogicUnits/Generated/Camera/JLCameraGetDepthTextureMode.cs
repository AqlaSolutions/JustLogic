using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Depth Texture Mode")]
[UnitFriendlyName("Camera.Get Depth Texture Mode")]
[UnitUsage(typeof(DepthTextureMode), HideExpressionInActionsList = true)]
public class JLCameraGetDepthTextureMode : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.depthTextureMode;
    }
}
