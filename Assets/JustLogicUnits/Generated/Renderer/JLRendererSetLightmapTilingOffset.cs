using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Lightmap Tiling Offset")]
[UnitFriendlyName("Renderer.Set Lightmap Tiling Offset")]
[UnitUsage(typeof(UnityEngine.Vector4))]
public class JLRendererSetLightmapTilingOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.lightmapScaleOffset = Value.GetResult<UnityEngine.Vector4>(context);
    }
}
