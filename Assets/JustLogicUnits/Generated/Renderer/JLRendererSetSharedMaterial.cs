using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Shared Material")]
[UnitFriendlyName("Renderer.Set Shared Material")]
[UnitUsage(typeof(UnityEngine.Material))]
public class JLRendererSetSharedMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Material))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.sharedMaterial = Value.GetResult<UnityEngine.Material>(context);
    }
}
