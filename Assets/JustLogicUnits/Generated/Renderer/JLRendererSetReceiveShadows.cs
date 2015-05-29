using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Receive Shadows")]
[UnitFriendlyName("Renderer.Set Receive Shadows")]
[UnitUsage(typeof(System.Boolean))]
public class JLRendererSetReceiveShadows : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.receiveShadows = Value.GetResult<System.Boolean>(context);
    }
}
