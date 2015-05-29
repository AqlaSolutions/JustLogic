using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get World To Camera Matrix")]
[UnitFriendlyName("Camera.Get World To Camera Matrix")]
[UnitUsage(typeof(UnityEngine.Matrix4x4), HideExpressionInActionsList = true)]
public class JLCameraGetWorldToCameraMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.worldToCameraMatrix;
    }
}
