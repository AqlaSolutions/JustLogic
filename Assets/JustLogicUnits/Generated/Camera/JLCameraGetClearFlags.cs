using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Clear Flags")]
[UnitFriendlyName("Camera.Get Clear Flags")]
[UnitUsage(typeof(UnityEngine.CameraClearFlags), HideExpressionInActionsList = true)]
public class JLCameraGetClearFlags : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.clearFlags;
    }
}
