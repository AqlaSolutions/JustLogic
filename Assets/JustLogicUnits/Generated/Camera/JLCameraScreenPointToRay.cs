using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Screen Point To Ray")]
[UnitFriendlyName("Camera.Screen Point To Ray")]
[UnitUsage(typeof(Ray), HideExpressionInActionsList = true)]
public class JLCameraScreenPointToRay : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.ScreenPointToRay(Position.GetResult<Vector3>(context));
    }
}
