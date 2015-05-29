using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Viewport Point To Ray")]
[UnitFriendlyName("Camera.Viewport Point To Ray")]
[UnitUsage(typeof(UnityEngine.Ray), HideExpressionInActionsList = true)]
public class JLCameraViewportPointToRay : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.ViewportPointToRay(Position.GetResult<UnityEngine.Vector3>(context));
    }
}
