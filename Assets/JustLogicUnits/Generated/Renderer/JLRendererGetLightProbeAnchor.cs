using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Light Probe Anchor")]
[UnitFriendlyName("Renderer.Get Light Probe Anchor")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLRendererGetLightProbeAnchor : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.probeAnchor;
    }
}
