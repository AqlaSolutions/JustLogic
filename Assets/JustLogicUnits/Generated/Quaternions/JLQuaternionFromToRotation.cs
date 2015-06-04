using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/From To Rotation")]
[UnitFriendlyName("From To Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionFromToRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression FromDirection;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression ToDirection;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.FromToRotation(FromDirection.GetResult<Vector3>(context), ToDirection.GetResult<Vector3>(context));
    }
}
