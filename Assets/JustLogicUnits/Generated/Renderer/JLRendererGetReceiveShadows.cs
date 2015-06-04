using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Receive Shadows")]
[UnitFriendlyName("Renderer.Get Receive Shadows")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetReceiveShadows : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.receiveShadows;
    }
}
