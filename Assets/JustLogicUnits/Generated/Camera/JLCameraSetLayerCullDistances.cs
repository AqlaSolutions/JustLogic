using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Set Layer Cull Distances")]
[UnitFriendlyName("Camera.Set Layer Cull Distances")]
[UnitUsage(typeof(System.Single[]))]
public class JLCameraSetLayerCullDistances : JLExpression
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Camera opValue = OperandValue.GetResult<Camera>(context);
        return opValue.layerCullDistances = Value.GetResult<System.Single>(context);
    }
}
