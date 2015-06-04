using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Particle System")]
[UnitFriendlyName("Renderer.Get Particle System")]
[UnitUsage(typeof(ParticleSystem), HideExpressionInActionsList = true)]
public class JLRendererGetParticleSystem : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.GetComponent<ParticleSystem>();
    }
}
