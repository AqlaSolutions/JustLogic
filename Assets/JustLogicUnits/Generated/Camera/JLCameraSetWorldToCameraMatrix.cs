using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set World To Camera Matrix")]
[UnitFriendlyName("Camera.Set World To Camera Matrix")]
[UnitUsage(typeof(UnityEngine.Matrix4x4))]
public class JLCameraSetWorldToCameraMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Matrix4x4))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.worldToCameraMatrix = Value.GetResult<UnityEngine.Matrix4x4>(context);
    }
}
