using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get On Unit Sphere")]
[UnitFriendlyName("Random.Get On Unit Sphere")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLRandomGetOnUnitSphere : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Random.onUnitSphere;
    }
}
