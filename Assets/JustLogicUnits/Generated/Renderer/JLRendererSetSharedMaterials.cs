using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Shared Materials")]
[UnitFriendlyName("Renderer.Set Shared Materials")]
[UnitUsage(typeof(UnityEngine.Material[]))]
public class JLRendererSetSharedMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Material))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.sharedMaterials = Value.GetResult<UnityEngine.Material>(context);
    }
}
