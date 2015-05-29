using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Render Dont Restore")]
[UnitFriendlyName("Camera.Render Dont Restore")]
public class JLCameraRenderDontRestore : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        opValue.RenderDontRestore();
        return null;
    }
}
