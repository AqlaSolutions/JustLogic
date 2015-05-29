using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Clear Stencil After Lighting Pass")]
[UnitFriendlyName("Camera.Get Clear Stencil After Lighting Pass")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCameraGetClearStencilAfterLightingPass : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.clearStencilAfterLightingPass;
    }
}
