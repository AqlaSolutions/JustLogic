using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Target Buffers")]
[UnitFriendlyName("Camera.Set Target Buffers")]
public class JLCameraSetTargetBuffers : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.RenderBuffer))]
    public JLExpression ColorBuffer;

    [Parameter(ExpressionType = typeof(UnityEngine.RenderBuffer))]
    public JLExpression DepthBuffer;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        opValue.SetTargetBuffers(ColorBuffer.GetResult<UnityEngine.RenderBuffer>(context), DepthBuffer.GetResult<UnityEngine.RenderBuffer>(context));
        return null;
    }
}
