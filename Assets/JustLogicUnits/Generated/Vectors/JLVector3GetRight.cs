using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Right (Vector3)")]
[UnitFriendlyName("Get Right")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetRight : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.right;
    }
}
