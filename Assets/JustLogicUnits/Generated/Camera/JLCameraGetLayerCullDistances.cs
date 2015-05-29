using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Layer Cull Distances")]
[UnitFriendlyName("Camera.Get Layer Cull Distances")]
[UnitUsage(typeof(System.Single[]), HideExpressionInActionsList = true)]
public class JLCameraGetLayerCullDistances : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Camera opValue = OperandValue.GetResult<UnityEngine.Camera>(context);
        return opValue.layerCullDistances;
    }
}
