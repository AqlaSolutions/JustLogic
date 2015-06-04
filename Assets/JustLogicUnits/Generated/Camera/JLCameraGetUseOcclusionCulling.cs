using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Use Occlusion Culling")]
[UnitFriendlyName("Camera.Get Use Occlusion Culling")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLCameraGetUseOcclusionCulling : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.useOcclusionCulling;
    }
}
