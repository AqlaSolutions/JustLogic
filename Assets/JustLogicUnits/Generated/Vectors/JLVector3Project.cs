using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Project (Vector3)")]
[UnitFriendlyName("Project")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Project : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Vector;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression OnNormal;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Project(Vector.GetResult<UnityEngine.Vector3>(context), OnNormal.GetResult<UnityEngine.Vector3>(context));
    }
}
