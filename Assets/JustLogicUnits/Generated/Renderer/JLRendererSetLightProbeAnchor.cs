using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Light Probe Anchor")]
[UnitFriendlyName("Renderer.Set Light Probe Anchor")]
[UnitUsage(typeof(UnityEngine.Transform))]
public class JLRendererSetLightProbeAnchor : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.probeAnchor = Value.GetResult<UnityEngine.Transform>(context);
    }
}
