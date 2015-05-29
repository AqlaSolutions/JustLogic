using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Material")]
[UnitFriendlyName("Renderer.Get Material")]
[UnitUsage(typeof(UnityEngine.Material), HideExpressionInActionsList = true)]
public class JLRendererGetMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.material;
    }
}
