using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Copy From")]
[UnitFriendlyName("Camera.Copy From")]
public class JLCameraCopyFrom : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression Other;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        opValue.CopyFrom(Other.GetResult<Camera>(context));
        return null;
    }
}
