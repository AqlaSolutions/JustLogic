using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Zero (Vector4)")]
[UnitFriendlyName("Get Zero")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4GetZero : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.zero;
    }
}
