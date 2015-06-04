using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get One (Vector2)")]
[UnitFriendlyName("Get One")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2GetOne : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.one;
    }
}
