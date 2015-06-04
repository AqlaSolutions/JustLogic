using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Replacement Shader")]
[UnitFriendlyName("Camera.Set Replacement Shader")]
public class JLCameraSetReplacementShader : JLAction
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
        opValue.SetReplacementShader(Shader.GetResult<Shader>(context), ReplacementTag.GetResult<System.String>(context));
        return null;
    }
}
