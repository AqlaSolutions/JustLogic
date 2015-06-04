using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector4)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector4.MoveTowards(Current.GetResult<Vector4>(context), Target.GetResult<Vector4>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
