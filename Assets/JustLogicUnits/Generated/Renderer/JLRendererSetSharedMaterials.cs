using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Shared Materials")]
[UnitFriendlyName("Renderer.Set Shared Materials")]
[UnitUsage(typeof(Material[]))]
public class JLRendererSetSharedMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Material))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.sharedMaterials = Value.GetResult<Material>(context);
    }
}
