using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Project (Vector4)")]
[UnitFriendlyName("Project")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4Project : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector4.Project(A.GetResult<UnityEngine.Vector4>(context), B.GetResult<UnityEngine.Vector4>(context));
    }
}
