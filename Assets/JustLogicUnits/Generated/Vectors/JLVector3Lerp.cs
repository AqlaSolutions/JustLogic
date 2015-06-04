using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector3)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Lerp(From.GetResult<Vector3>(context), To.GetResult<Vector3>(context), T.GetResult<System.Single>(context));
    }
}
