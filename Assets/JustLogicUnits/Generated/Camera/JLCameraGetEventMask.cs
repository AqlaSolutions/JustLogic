using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Event Mask")]
[UnitFriendlyName("Camera.Get Event Mask")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLCameraGetEventMask : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.eventMask;
    }
}
