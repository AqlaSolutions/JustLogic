using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Clear Flags")]
[UnitFriendlyName("Camera.Get Clear Flags")]
[UnitUsage(typeof(CameraClearFlags), HideExpressionInActionsList = true)]
public class JLCameraGetClearFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.clearFlags;
    }
}
