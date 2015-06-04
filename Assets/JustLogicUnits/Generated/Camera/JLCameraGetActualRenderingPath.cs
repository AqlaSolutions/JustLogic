using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Actual Rendering Path")]
[UnitFriendlyName("Camera.Get Actual Rendering Path")]
[UnitUsage(typeof(RenderingPath), HideExpressionInActionsList = true)]
public class JLCameraGetActualRenderingPath : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.actualRenderingPath;
    }
}
