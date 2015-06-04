using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Lightmap Tiling Offset")]
[UnitFriendlyName("Renderer.Get Lightmap Tiling Offset")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLRendererGetLightmapTilingOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.lightmapScaleOffset;
    }
}
