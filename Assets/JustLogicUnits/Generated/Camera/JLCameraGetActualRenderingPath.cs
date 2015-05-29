using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Actual Rendering Path")]
[UnitFriendlyName("Camera.Get Actual Rendering Path")]
[UnitUsage(typeof(UnityEngine.RenderingPath), HideExpressionInActionsList = true)]
public class JLCameraGetActualRenderingPath : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.actualRenderingPath;
    }
}
