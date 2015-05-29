using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Depth Texture Mode")]
[UnitFriendlyName("Camera.Get Depth Texture Mode")]
[UnitUsage(typeof(UnityEngine.DepthTextureMode), HideExpressionInActionsList = true)]
public class JLCameraGetDepthTextureMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.depthTextureMode;
    }
}
