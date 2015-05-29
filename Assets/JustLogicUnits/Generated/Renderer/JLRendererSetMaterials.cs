using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Materials")]
[UnitFriendlyName("Renderer.Set Materials")]
[UnitUsage(typeof(UnityEngine.Material[]))]
public class JLRendererSetMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Material))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.materials = Value.GetResult<UnityEngine.Material>(context);
    }
}
