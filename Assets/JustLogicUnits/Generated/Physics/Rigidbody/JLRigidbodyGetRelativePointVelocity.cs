using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Relative Point Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get Relative Point Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyGetRelativePointVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression RelativePoint;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.GetRelativePointVelocity(RelativePoint.GetResult<Vector3>(context));
    }
}
