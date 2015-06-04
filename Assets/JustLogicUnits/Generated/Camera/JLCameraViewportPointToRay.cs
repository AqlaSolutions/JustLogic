using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Viewport Point To Ray")]
[UnitFriendlyName("Camera.Viewport Point To Ray")]
[UnitUsage(typeof(Ray), HideExpressionInActionsList = true)]
public class JLCameraViewportPointToRay : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ViewportPointToRay(Position.GetResult<Vector3>(context));
    }
}
