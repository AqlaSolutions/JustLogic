using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Clear Flags")]
[UnitFriendlyName("Camera.Set Clear Flags")]
[UnitUsage(typeof(CameraClearFlags))]
public class JLCameraSetClearFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(CameraClearFlags))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.clearFlags = Value.GetResult<CameraClearFlags>(context);
    }
}
