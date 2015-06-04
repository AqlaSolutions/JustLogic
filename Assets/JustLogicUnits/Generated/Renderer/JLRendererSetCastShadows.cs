using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[UnitMenu("Renderer/Set Cast Shadows")]
[UnitFriendlyName("Renderer.Set Cast Shadows")]
[UnitUsage(typeof(System.Boolean))]
public class JLRendererSetCastShadows : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.shadowCastingMode = Value.GetResult<System.Boolean>(context) ? ShadowCastingMode.On : ShadowCastingMode.Off;
    }
}
