using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Copy From")]
[UnitFriendlyName("Camera.Copy From")]
public class JLCameraCopyFrom : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression Other;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        opValue.CopyFrom(Other.GetResult<UnityEngine.Camera>(context));
        return null;
    }
}
