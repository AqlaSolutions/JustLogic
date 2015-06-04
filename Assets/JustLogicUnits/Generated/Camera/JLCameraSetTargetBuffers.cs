using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Target Buffers")]
[UnitFriendlyName("Camera.Set Target Buffers")]
public class JLCameraSetTargetBuffers : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(RenderBuffer))]
    public JLExpression ColorBuffer;

    [Parameter(ExpressionType = typeof(RenderBuffer))]
    public JLExpression DepthBuffer;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.SetTargetBuffers(ColorBuffer.GetResult<RenderBuffer>(context), DepthBuffer.GetResult<RenderBuffer>(context));
        return null;
    }
}
