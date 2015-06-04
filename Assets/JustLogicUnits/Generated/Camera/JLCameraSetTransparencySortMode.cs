using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Transparency Sort Mode")]
[UnitFriendlyName("Camera.Set Transparency Sort Mode")]
[UnitUsage(typeof(TransparencySortMode))]
public class JLCameraSetTransparencySortMode : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(TransparencySortMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.transparencySortMode = Value.GetResult<TransparencySortMode>(context);
    }
}
