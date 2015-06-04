using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Target Texture")]
[UnitFriendlyName("Camera.Set Target Texture")]
[UnitUsage(typeof(RenderTexture))]
public class JLCameraSetTargetTexture : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(RenderTexture))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.targetTexture = Value.GetResult<RenderTexture>(context);
    }
}
