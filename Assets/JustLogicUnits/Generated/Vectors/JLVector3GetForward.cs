using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Forward (Vector3)")]
[UnitFriendlyName("Get Forward")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetForward : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.forward;
    }
}
