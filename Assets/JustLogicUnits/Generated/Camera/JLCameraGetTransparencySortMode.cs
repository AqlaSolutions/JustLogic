using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Transparency Sort Mode")]
[UnitFriendlyName("Camera.Get Transparency Sort Mode")]
[UnitUsage(typeof(UnityEngine.TransparencySortMode), HideExpressionInActionsList = true)]
public class JLCameraGetTransparencySortMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.transparencySortMode;
    }
}
