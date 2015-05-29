using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Particle Emitter")]
[UnitFriendlyName("Get Particle Emitter")]
[UnitUsage(typeof(UnityEngine.ParticleEmitter), HideExpressionInActionsList = true)]
public class JLGameObjectGetParticleEmitter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<ParticleEmitter>();
    }
}
