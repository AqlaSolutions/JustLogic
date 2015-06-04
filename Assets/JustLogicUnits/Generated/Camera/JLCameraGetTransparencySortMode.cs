using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Transparency Sort Mode")]
[UnitFriendlyName("Camera.Get Transparency Sort Mode")]
[UnitUsage(typeof(TransparencySortMode), HideExpressionInActionsList = true)]
public class JLCameraGetTransparencySortMode : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.transparencySortMode;
    }
}
