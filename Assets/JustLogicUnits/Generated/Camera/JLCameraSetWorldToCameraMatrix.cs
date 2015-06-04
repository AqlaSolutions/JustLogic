using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set World To Camera Matrix")]
[UnitFriendlyName("Camera.Set World To Camera Matrix")]
[UnitUsage(typeof(Matrix4x4))]
public class JLCameraSetWorldToCameraMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Matrix4x4))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.worldToCameraMatrix = Value.GetResult<Matrix4x4>(context);
    }
}
