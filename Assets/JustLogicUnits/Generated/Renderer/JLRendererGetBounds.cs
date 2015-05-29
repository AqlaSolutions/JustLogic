using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Bounds")]
[UnitFriendlyName("Renderer.Get Bounds")]
[UnitUsage(typeof(UnityEngine.Bounds), HideExpressionInActionsList = true)]
public class JLRendererGetBounds : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.bounds;
    }
}
