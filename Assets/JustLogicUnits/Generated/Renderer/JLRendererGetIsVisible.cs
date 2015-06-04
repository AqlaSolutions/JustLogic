using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Is Visible")]
[UnitFriendlyName("Renderer.Get Is Visible")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetIsVisible : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.isVisible;
    }
}
