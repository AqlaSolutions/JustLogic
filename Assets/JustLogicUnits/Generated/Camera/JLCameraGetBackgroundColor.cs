using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Background Color")]
[UnitFriendlyName("Camera.Get Background Color")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLCameraGetBackgroundColor : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.backgroundColor;
    }
}
