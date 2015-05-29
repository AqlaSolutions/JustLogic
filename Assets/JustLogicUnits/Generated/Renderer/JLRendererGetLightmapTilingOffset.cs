using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Lightmap Tiling Offset")]
[UnitFriendlyName("Renderer.Get Lightmap Tiling Offset")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLRendererGetLightmapTilingOffset : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.lightmapScaleOffset;
    }
}
