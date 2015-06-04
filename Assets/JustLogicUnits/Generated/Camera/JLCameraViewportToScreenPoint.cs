using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Viewport To Screen Point")]
[UnitFriendlyName("Camera.Viewport To Screen Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCameraViewportToScreenPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ViewportToScreenPoint(Position.GetResult<Vector3>(context));
    }
}
