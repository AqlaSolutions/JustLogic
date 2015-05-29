using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Target Texture")]
[UnitFriendlyName("Camera.Set Target Texture")]
[UnitUsage(typeof(UnityEngine.RenderTexture))]
public class JLCameraSetTargetTexture : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.RenderTexture))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.targetTexture = Value.GetResult<UnityEngine.RenderTexture>(context);
    }
}
