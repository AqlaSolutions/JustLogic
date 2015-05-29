using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get Inside Unit Sphere")]
[UnitFriendlyName("Random.Get Inside Unit Sphere")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLRandomGetInsideUnitSphere : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.insideUnitSphere;
    }
}
