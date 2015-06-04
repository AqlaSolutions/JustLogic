using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Use Light Probes")]
[UnitFriendlyName("Renderer.Get Use Light Probes")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetUseLightProbes : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.useLightProbes;
    }
}
