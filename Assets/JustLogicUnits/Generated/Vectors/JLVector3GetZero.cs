using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Zero (Vector3)")]
[UnitFriendlyName("Get Zero")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetZero : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.zero;
    }
}
