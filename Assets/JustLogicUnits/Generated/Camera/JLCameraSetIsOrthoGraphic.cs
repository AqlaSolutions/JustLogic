using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Is Ortho Graphic")]
[UnitFriendlyName("Camera.Set Is Ortho Graphic")]
[UnitUsage(typeof(System.Boolean))]
public class JLCameraSetIsOrthoGraphic : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.orthographic = Value.GetResult<System.Boolean>(context);
    }
}
