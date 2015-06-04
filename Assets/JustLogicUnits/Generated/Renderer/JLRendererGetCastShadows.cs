using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Cast Shadows")]
[UnitFriendlyName("Renderer.Get Cast Shadows")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetCastShadows : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.castShadows;
    }
}
