using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Particle System")]
[UnitFriendlyName("Renderer.Get Particle System")]
[UnitUsage(typeof(UnityEngine.ParticleSystem), HideExpressionInActionsList = true)]
public class JLRendererGetParticleSystem : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.GetComponent<ParticleSystem>();
    }
}
