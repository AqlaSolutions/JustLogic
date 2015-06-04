using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Use Occlusion Culling")]
[UnitFriendlyName("Camera.Set Use Occlusion Culling")]
[UnitUsage(typeof(System.Boolean))]
public class JLCameraSetUseOcclusionCulling : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.useOcclusionCulling = Value.GetResult<System.Boolean>(context);
    }
}
