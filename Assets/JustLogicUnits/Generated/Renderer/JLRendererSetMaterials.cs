using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Materials")]
[UnitFriendlyName("Renderer.Set Materials")]
[UnitUsage(typeof(Material[]))]
public class JLRendererSetMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Material))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.materials = Value.GetResult<Material>(context);
    }
}
