using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Render With Shader")]
[UnitFriendlyName("Camera.Render With Shader")]
public class JLCameraRenderWithShader : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Shader))]
    public JLExpression Shader;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression ReplacementTag;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.RenderWithShader(Shader.GetResult<Shader>(context), ReplacementTag.GetResult<System.String>(context));
        return null;
    }
}
