using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Particle Emitter")]
[UnitFriendlyName("Get Particle Emitter")]
[UnitUsage(typeof(ParticleEmitter), HideExpressionInActionsList = true)]
public class JLGameObjectGetParticleEmitter : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<ParticleEmitter>();
    }
}
