using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Viewport To World Point")]
[UnitFriendlyName("Camera.Viewport To World Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCameraViewportToWorldPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ViewportToWorldPoint(Position.GetResult<Vector3>(context));
    }
}
