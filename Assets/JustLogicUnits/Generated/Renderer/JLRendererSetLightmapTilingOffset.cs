using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Lightmap Tiling Offset")]
[UnitFriendlyName("Renderer.Set Lightmap Tiling Offset")]
[UnitUsage(typeof(Vector4))]
public class JLRendererSetLightmapTilingOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.lightmapScaleOffset = Value.GetResult<Vector4>(context);
    }
}
