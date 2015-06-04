using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Shared Materials")]
[UnitFriendlyName("Renderer.Get Shared Materials")]
[UnitUsage(typeof(Material[]), HideExpressionInActionsList = true)]
public class JLRendererGetSharedMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.sharedMaterials;
    }
}
