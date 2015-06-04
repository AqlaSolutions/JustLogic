using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Project (Vector3)")]
[UnitFriendlyName("Project")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Project : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Vector;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression OnNormal;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Project(Vector.GetResult<Vector3>(context), OnNormal.GetResult<Vector3>(context));
    }
}
