using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Replacement Shader")]
[UnitFriendlyName("Camera.Set Replacement Shader")]
public class JLCameraSetReplacementShader : JLAction
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
        opValue.SetReplacementShader(Shader.GetResult<UnityEngine.Shader>(context), ReplacementTag.GetResult<System.String>(context));
        return null;
    }
}
