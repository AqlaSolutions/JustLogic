using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Clear Flags")]
[UnitFriendlyName("Camera.Set Clear Flags")]
[UnitUsage(typeof(UnityEngine.CameraClearFlags))]
public class JLCameraSetClearFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.CameraClearFlags))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.clearFlags = Value.GetResult<UnityEngine.CameraClearFlags>(context);
    }
}
