using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Render Dont Restore")]
[UnitFriendlyName("Camera.Render Dont Restore")]
public class JLCameraRenderDontRestore : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.RenderDontRestore();
        return null;
    }
}
