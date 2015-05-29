using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Lightmap Index")]
[UnitFriendlyName("Renderer.Set Lightmap Index")]
[UnitUsage(typeof(System.Int32))]
public class JLRendererSetLightmapIndex : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.lightmapIndex = Value.GetResult<System.Int32>(context);
    }
}
