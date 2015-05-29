using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Clear Stencil After Lighting Pass")]
[UnitFriendlyName("Camera.Set Clear Stencil After Lighting Pass")]
[UnitUsage(typeof(System.Boolean))]
public class JLCameraSetClearStencilAfterLightingPass : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.clearStencilAfterLightingPass = Value.GetResult<System.Boolean>(context);
    }
}
