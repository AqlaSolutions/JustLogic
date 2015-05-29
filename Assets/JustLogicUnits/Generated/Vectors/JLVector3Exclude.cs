using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Exclude (Vector3)")]
[UnitFriendlyName("Exclude")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Exclude : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression ExcludeThis;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression FromThat;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Exclude(ExcludeThis.GetResult<UnityEngine.Vector3>(context), FromThat.GetResult<UnityEngine.Vector3>(context));
    }
}
