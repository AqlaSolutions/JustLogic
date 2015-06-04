using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Angle (Vector3)")]
[UnitFriendlyName("Angle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3Angle : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression To;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Angle(From.GetResult<Vector3>(context), To.GetResult<Vector3>(context));
    }
}
