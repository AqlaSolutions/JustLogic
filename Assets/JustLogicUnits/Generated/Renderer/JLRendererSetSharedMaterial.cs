using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Shared Material")]
[UnitFriendlyName("Renderer.Set Shared Material")]
[UnitUsage(typeof(Material))]
public class JLRendererSetSharedMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Material))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.sharedMaterial = Value.GetResult<Material>(context);
    }
}
