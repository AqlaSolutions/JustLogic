using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Material")]
[UnitFriendlyName("Renderer.Get Material")]
[UnitUsage(typeof(Material), HideExpressionInActionsList = true)]
public class JLRendererGetMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.material;
    }
}
