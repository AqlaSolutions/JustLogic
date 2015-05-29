using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Light Probe Anchor")]
[UnitFriendlyName("Renderer.Get Light Probe Anchor")]
[UnitUsage(typeof(UnityEngine.Transform), HideExpressionInActionsList = true)]
public class JLRendererGetLightProbeAnchor : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.probeAnchor;
    }
}
