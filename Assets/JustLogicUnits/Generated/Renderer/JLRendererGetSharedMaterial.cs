using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Shared Material")]
[UnitFriendlyName("Renderer.Get Shared Material")]
[UnitUsage(typeof(Material), HideExpressionInActionsList = true)]
public class JLRendererGetSharedMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.sharedMaterial;
    }
}
