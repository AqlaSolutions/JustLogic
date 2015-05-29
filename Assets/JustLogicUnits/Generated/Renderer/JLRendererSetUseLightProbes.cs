using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Use Light Probes")]
[UnitFriendlyName("Renderer.Set Use Light Probes")]
[UnitUsage(typeof(System.Boolean))]
public class JLRendererSetUseLightProbes : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.useLightProbes = Value.GetResult<System.Boolean>(context);
    }
}
