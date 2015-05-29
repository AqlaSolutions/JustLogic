using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Particle Emitter")]
[UnitFriendlyName("Renderer.Get Particle Emitter")]
[UnitUsage(typeof(UnityEngine.ParticleEmitter), HideExpressionInActionsList = true)]
public class JLRendererGetParticleEmitter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.GetComponent<ParticleEmitter>();
    }
}
