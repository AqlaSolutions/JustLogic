using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Materials")]
[UnitFriendlyName("Renderer.Get Materials")]
[UnitUsage(typeof(Material[]), HideExpressionInActionsList = true)]
public class JLRendererGetMaterials : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.materials;
    }
}
