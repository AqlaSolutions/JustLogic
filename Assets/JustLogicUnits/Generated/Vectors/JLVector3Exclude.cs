using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Exclude (Vector3)")]
[UnitFriendlyName("Exclude")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Exclude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression ExcludeThis;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression FromThat;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Exclude(ExcludeThis.GetResult<Vector3>(context), FromThat.GetResult<Vector3>(context));
    }
}
