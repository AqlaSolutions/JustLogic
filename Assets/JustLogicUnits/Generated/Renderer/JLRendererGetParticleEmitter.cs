using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Particle Emitter")]
[UnitFriendlyName("Renderer.Get Particle Emitter")]
[UnitUsage(typeof(ParticleEmitter), HideExpressionInActionsList = true)]
public class JLRendererGetParticleEmitter : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.GetComponent<ParticleEmitter>();
    }
}
