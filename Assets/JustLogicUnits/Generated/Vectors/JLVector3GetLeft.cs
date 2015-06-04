using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Left (Vector3)")]
[UnitFriendlyName("Get Left")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetLeft : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.left;
    }
}
