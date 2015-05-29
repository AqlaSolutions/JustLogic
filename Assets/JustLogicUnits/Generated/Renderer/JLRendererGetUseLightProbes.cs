using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Use Light Probes")]
[UnitFriendlyName("Renderer.Get Use Light Probes")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetUseLightProbes : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.useLightProbes;
    }
}
