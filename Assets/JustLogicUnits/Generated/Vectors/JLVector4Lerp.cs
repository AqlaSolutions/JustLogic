using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector4)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.Lerp(From.GetResult<Vector4>(context), To.GetResult<Vector4>(context), T.GetResult<System.Single>(context));
    }
}
