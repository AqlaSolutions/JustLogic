using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Op Multiply with Vector3")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLQuaternionOpMultiply2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Rotation;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Point;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Rotation.GetResult<Quaternion>(context) * Point.GetResult<Vector3>(context);
    }
}
