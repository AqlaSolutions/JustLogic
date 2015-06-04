using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Back (Vector3)")]
[UnitFriendlyName("Get Back")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetBack : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.back;
    }
}
