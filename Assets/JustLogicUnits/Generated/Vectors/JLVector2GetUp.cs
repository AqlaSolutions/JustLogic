using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Up (Vector2)")]
[UnitFriendlyName("Get Up")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLVector2GetUp : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector2.up;
    }
}
