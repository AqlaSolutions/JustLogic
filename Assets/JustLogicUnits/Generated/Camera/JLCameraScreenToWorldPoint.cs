using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Screen To World Point")]
[UnitFriendlyName("Camera.Screen To World Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCameraScreenToWorldPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ScreenToWorldPoint(Position.GetResult<Vector3>(context));
    }
}
