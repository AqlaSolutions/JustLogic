using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Reflect (Vector3)")]
[UnitFriendlyName("Reflect")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Reflect : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression InDirection;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression InNormal;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Reflect(InDirection.GetResult<UnityEngine.Vector3>(context), InNormal.GetResult<UnityEngine.Vector3>(context));
    }
}
