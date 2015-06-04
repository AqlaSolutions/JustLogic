using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Light Probe Anchor")]
[UnitFriendlyName("Renderer.Set Light Probe Anchor")]
[UnitUsage(typeof(Transform))]
public class JLRendererSetLightProbeAnchor : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.probeAnchor = Value.GetResult<Transform>(context);
    }
}
