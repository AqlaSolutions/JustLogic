using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Is Visible")]
[UnitFriendlyName("Renderer.Get Is Visible")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetIsVisible : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.isVisible;
    }
}
