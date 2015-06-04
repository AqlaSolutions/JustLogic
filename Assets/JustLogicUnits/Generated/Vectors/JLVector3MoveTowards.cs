using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector3)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.MoveTowards(Current.GetResult<Vector3>(context), Target.GetResult<Vector3>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
