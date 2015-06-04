using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Bounds")]
[UnitFriendlyName("Renderer.Get Bounds")]
[UnitUsage(typeof(Bounds), HideExpressionInActionsList = true)]
public class JLRendererGetBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.bounds;
    }
}
