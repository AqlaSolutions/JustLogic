using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Particle System")]
[UnitFriendlyName("Get Particle System")]
[UnitUsage(typeof(ParticleSystem), HideExpressionInActionsList = true)]
public class JLGameObjectGetParticleSystem : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<ParticleSystem>();
    }
}
