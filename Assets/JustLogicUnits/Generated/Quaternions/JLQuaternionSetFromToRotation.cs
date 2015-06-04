using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set From To Rotation")]
[UnitFriendlyName("Set From To Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSetFromToRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression FromDirection;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression ToDirection;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        opValue.SetFromToRotation(FromDirection.GetResult<Vector3>(context), ToDirection.GetResult<Vector3>(context));
        return opValue;
    }
}
