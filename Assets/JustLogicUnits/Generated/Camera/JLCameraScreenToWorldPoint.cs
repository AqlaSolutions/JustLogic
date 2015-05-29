using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Screen To World Point")]
[UnitFriendlyName("Camera.Screen To World Point")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLCameraScreenToWorldPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.ScreenToWorldPoint(Position.GetResult<UnityEngine.Vector3>(context));
    }
}
