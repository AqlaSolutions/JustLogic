using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Down (Vector3)")]
[UnitFriendlyName("Get Down")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetDown : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.down;
    }
}
