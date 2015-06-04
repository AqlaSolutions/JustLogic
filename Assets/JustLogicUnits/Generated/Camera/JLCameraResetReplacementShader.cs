using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Reset Replacement Shader")]
[UnitFriendlyName("Camera.Reset Replacement Shader")]
public class JLCameraResetReplacementShader : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.ResetReplacementShader();
        return null;
    }
}
