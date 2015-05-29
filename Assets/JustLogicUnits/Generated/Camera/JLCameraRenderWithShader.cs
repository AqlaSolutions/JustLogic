using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Render With Shader")]
[UnitFriendlyName("Camera.Render With Shader")]
public class JLCameraRenderWithShader : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Shader))]
    public JLExpression Shader;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression ReplacementTag;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        opValue.RenderWithShader(Shader.GetResult<UnityEngine.Shader>(context), ReplacementTag.GetResult<System.String>(context));
        return null;
    }
}
