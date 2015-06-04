using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Velocity")]
[UnitFriendlyName("Camera.Get Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCameraGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.velocity;
    }
}
