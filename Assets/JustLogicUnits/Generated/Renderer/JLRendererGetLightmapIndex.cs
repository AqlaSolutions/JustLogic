using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Lightmap Index")]
[UnitFriendlyName("Renderer.Get Lightmap Index")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLRendererGetLightmapIndex : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.lightmapIndex;
    }
}
