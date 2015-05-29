using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Op Multiply with Vector3")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLQuaternionOpMultiply2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Rotation;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Point;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Rotation.GetResult<UnityEngine.Quaternion>(context) * Point.GetResult<UnityEngine.Vector3>(context);
    }
}
