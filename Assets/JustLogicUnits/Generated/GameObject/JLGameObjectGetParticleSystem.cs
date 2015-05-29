using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Particle System")]
[UnitFriendlyName("Get Particle System")]
[UnitUsage(typeof(UnityEngine.ParticleSystem), HideExpressionInActionsList = true)]
public class JLGameObjectGetParticleSystem : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<ParticleSystem>();
    }
}
