using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Up (Vector3)")]
[UnitFriendlyName("Get Up")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetUp : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.up;
    }
}
