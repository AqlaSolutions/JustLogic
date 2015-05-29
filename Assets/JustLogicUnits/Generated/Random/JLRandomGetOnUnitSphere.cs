using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get On Unit Sphere")]
[UnitFriendlyName("Random.Get On Unit Sphere")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLRandomGetOnUnitSphere : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.onUnitSphere;
    }
}
