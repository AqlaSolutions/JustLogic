using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Rotate Towards (Vector3)")]
[UnitFriendlyName("Rotate Towards")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3RotateTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxRadiansDelta;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxMagnitudeDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.RotateTowards(Current.GetResult<Vector3>(context), Target.GetResult<Vector3>(context), MaxRadiansDelta.GetResult<System.Single>(context), MaxMagnitudeDelta.GetResult<System.Single>(context));
    }
}
