using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Render")]
[UnitFriendlyName("Camera.Render")]
public class JLCameraRender : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.Render();
        return null;
    }
}
