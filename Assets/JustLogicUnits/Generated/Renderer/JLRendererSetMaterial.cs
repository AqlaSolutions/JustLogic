using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Material")]
[UnitFriendlyName("Renderer.Set Material")]
[UnitUsage(typeof(Material))]
public class JLRendererSetMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Material))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.material = Value.GetResult<Material>(context);
    }
}
