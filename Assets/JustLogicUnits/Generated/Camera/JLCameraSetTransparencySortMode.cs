using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Transparency Sort Mode")]
[UnitFriendlyName("Camera.Set Transparency Sort Mode")]
[UnitUsage(typeof(UnityEngine.TransparencySortMode))]
public class JLCameraSetTransparencySortMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.TransparencySortMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.transparencySortMode = Value.GetResult<UnityEngine.TransparencySortMode>(context);
    }
}
