using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get One (Vector3)")]
[UnitFriendlyName("Get One")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetOne : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.one;
    }
}
