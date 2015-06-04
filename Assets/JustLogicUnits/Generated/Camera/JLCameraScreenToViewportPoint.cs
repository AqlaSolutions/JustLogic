using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Screen To Viewport Point")]
[UnitFriendlyName("Camera.Screen To Viewport Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCameraScreenToViewportPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ScreenToViewportPoint(Position.GetResult<Vector3>(context));
    }
}
