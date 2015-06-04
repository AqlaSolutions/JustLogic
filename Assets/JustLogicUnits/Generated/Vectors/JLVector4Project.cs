using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Project (Vector4)")]
[UnitFriendlyName("Project")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4Project : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.Project(A.GetResult<Vector4>(context), B.GetResult<Vector4>(context));
    }
}
