using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Material")]
[UnitFriendlyName("Renderer.Set Material")]
[UnitUsage(typeof(UnityEngine.Material))]
public class JLRendererSetMaterial : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Material))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.material = Value.GetResult<UnityEngine.Material>(context);
    }
}
