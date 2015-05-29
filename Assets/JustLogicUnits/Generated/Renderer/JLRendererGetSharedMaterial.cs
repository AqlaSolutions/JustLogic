using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Shared Material")]
[UnitFriendlyName("Renderer.Get Shared Material")]
[UnitUsage(typeof(UnityEngine.Material), HideExpressionInActionsList = true)]
public class JLRendererGetSharedMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.sharedMaterial;
    }
}
